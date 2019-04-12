using System;
using System.Linq;
using System.Collections.Generic;
using SD.LLBLGen.Pro.QuerySpec;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.data_access.sql.EntityClasses;
using webapi22.example.data_access.sql.CollectionClasses;
using webapi22.example.data_access.sql.FactoryClasses;
using webapi22.example.data_access.sql.HelperClasses;
using webapi22.example.data_access.sql.DaoClasses;
using webapi22.example.dtos.Persistence;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;

namespace webapi22.example.data_access.sql.dal
{
    public static class DAL
    {
        public static List<Tuple<bool, string>> ValidatePath(Guid userId, Guid listId)
        {
            var qf = new QueryFactory();
            var q = qf.TodoList
                .Where(TodoListFields.TodoListId.Equal(listId)
                    .And(TodoListFields.UserId.Equal(userId))
                );

            var itemExists = new TodoListDAO().GetScalar<bool>(qf.Create().Select(q.Any()), null);

            var validTodoItemResults = new List<Tuple<bool, string>>();
            validTodoItemResults.Add(new Tuple<bool, string>(itemExists,
                !itemExists ? "Todo item doesn't exist." : string.Empty));

            return validTodoItemResults;
            //var result = new List<Tuple<bool, string>>();

            //bool exists = MockDB._todoList.Where(l => l.TodoListId == listId && l.UserId == userId).ToList().Count > 0;

            //result.Add(new Tuple<bool, string>(exists, !exists ? "Todo list doesn't exist." : string.Empty));
            //return result;
        }

        public static List<Tuple<bool, string>> ValidatePath(Guid userId, Guid listId, Guid itemId)
        {
            var qf = new QueryFactory();
            var q = qf.TodoListItem
                .From(QueryTarget.InnerJoin(qf.TodoList)
                    .On(TodoListFields.TodoListId.Equal(TodoListItemFields.TodoListId)))
                .Where(TodoListItemFields.TodoListId.Equal(listId)
                    .And(TodoListItemFields.TodoListItemId.Equal(itemId)
                        .And(TodoListFields.UserId.Equal(userId))
                    )
                );

            var itemExists = new TodoListDAO().GetScalar<bool>(qf.Create().Select(q.Any()), null);

            var validTodoItemResults = new List<Tuple<bool, string>>();
            validTodoItemResults.Add( new Tuple<bool, string>(itemExists, !itemExists ? "Todo item doesn't exist." : string.Empty));

            return validTodoItemResults;

            //var validationList = new List<Tuple<bool, string>>();

            //var validTodoListResults = ValidatePath(userId, listId);

            //bool exists = MockDB._todoListItems
            //                  .Where(i => i.TodoListId == listId && i.TodoListItemId == itemId &&
            //                              i.UserId == userId).ToList()
            //                  .Count > 0;

            //var validTodoItemResults = new Tuple<bool, string>(exists, !exists ? "Todo item doesn't exist." : string.Empty);

            //validationList.Add(validTodoListResults[0]);
            //validationList.Add(validTodoItemResults);

            //return validationList;
        }

        public static List<Tuple<bool, string>> ValidateUser(Guid userId)
        {
            var user = new UserEntity(userId);
            var validationResults = new List<Tuple<bool, string>>();

            validationResults.Add(new Tuple<bool, string>(!user.IsNew, user.IsNew ? "User doesn't exist." : string.Empty));

            return validationResults;

        }




        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            //return MockDB._userList.Select(u => new User() { UserId = u.UserId, UserName = u.UserName }).ToList();
            var userentities = new UserCollection().GetMulti<UserEntity>(new QueryFactory().User);
            foreach (UserEntity user in userentities)
            {
                users.Add(user.ProjectToUser());
            }
            return users;
        }

        public static ToDoListWithTodos GetTodoList(Guid userId, Guid todoListId)
        {
            var qf = new QueryFactory();

            var todolist = qf.TodoList
                .From(QueryTarget.InnerJoin(qf.TodoListItem)
                    .On(TodoListItemFields.TodoListId.Equal(TodoListFields.TodoListId)))
                //.Select(Projection.Full)
                .Where(TodoListFields.UserId.Equal(userId)
                    .And(TodoListFields.TodoListId.Equal(todoListId)
                    .And(TodoListItemFields.TodoListItemIsComplete.NotEqual(true)))).GetFirst();
            
            
            //((IQueryable<TodoListEntity>) todolist).ProjectToToDoListWithTodos();
            return todolist.ProjectToToDoListWithTodos();
        }

        public static UserTodoLists GetListsForUser(Guid userId)
        {
            List<UserTodoLists> todoLists = new List<UserTodoLists>();
            return new QueryFactory().User.Where(UserFields.UserId.Equal(userId)).GetFirst().ProjectToUserTodoLists();
        }

        public static ToDoListWithTodos CreateTodoList(Guid userId, ToDoListWithTodos newTodoListWithTodos)
        {
            var newlist = new TodoListEntity();
            newlist.UpdateFromToDoListWithTodos(newTodoListWithTodos);
            newlist.UserId = userId;
            newlist.TodoListId = Guid.NewGuid();

            foreach (var todoListItem in newTodoListWithTodos.TodoListItems)
            {
                newlist.TodoListItems.Add(new TodoListItemEntity()
                    {
                        TodoListItemId = Guid.NewGuid(),
                        TodoListItemSubject = todoListItem.TodoListItemSubject,
                        TodoListItemIsComplete = todoListItem.TodoListItemIsComplete,    
                    });
            }
            newlist.Save(true);

            return GetTodoList(userId, newlist.TodoListId);
        }

        public static ToDoListWithTodos UpdateTodoList(Guid userId, Guid todoListId, ToDoListWithTodos updatedtDoListWithTodos)
        {
            var listToUpdate = new QueryFactory().TodoList
                .Where(TodoListFields.UserId.Equal(userId).And(TodoListFields.TodoListId.Equal(todoListId))).GetFirst();

            listToUpdate.UpdateFromToDoListWithTodos(updatedtDoListWithTodos);

            foreach (var updatedItem in updatedtDoListWithTodos.TodoListItems)
            {
                var itemToUpdate =
                    listToUpdate.TodoListItems.Where(x => x.TodoListItemId == updatedItem.TodoListItemId)
                        .FirstOrDefault() ?? listToUpdate.TodoListItems.AddNew();

                itemToUpdate.TodoListId = listToUpdate.TodoListId;
                if (itemToUpdate.IsNew)
                    itemToUpdate.TodoListItemId = Guid.NewGuid();
                   
                itemToUpdate.TodoListItemSubject = updatedItem.TodoListItemSubject;
                itemToUpdate.TodoListItemIsComplete = updatedItem.TodoListItemIsComplete;
            }

            //foreach (Property p in newLead.Properties)
            //{
            //    var prop = customerentity.Properties.Where(x => x.PropertyId == p.PropertyId).FirstOrDefault() ?? customerentity.Properties.AddNew();
            //    prop.UpdateFromPropertyDerivedRoot(p);

            //    foreach (PropertyNote pn in p.PropertyNotes)
            //    {
            //        var note = prop.PropertyNotes.Where(x => x.PropertyNotesId == pn.PropertyNotesId).FirstOrDefault() ?? prop.PropertyNotes.AddNew();
            //        note.UpdateFromPropertyNoteDerivedRoot(pn);
            //    }
            //    foreach (PropertyNote pn in _deletedPropertyNotes)
            //    {
            //        var note = prop.PropertyNotes.Where(x => x.PropertyNotesId == pn.PropertyNotesId).FirstOrDefault();
            //        if (note != null) uow.AddForDelete(note);
            //    }
            //}

            listToUpdate.Save(true);

            return GetTodoList(userId, todoListId);
        }

        public static void DeleteTodoList(Guid userId, Guid todoListId)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            //MockDB._todoListItems.Where(i => i.TodoListId == todoListId).ToList().ForEach(item => MockDB._todoListItems.Remove(item));
            //MockDB._todoList.Where(l => l.TodoListId == todoListId).ToList().ForEach(list => MockDB._todoList.Remove(list));
        }


        public static Todo AddNewTodo(Guid userId, Guid todoListId, dtos.DtoClasses.Todo newItem)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            //var list = MockDB._todoList.Where(l => l.TodoListId == todoListId).ToList()[0];

            //var newid = Guid.NewGuid();

            //MockDB._todoListItems.Add(new TodoListItemEntityDtoRow()
            //{
            //    TodoListItemId = newid,
            //    TodoListId = todoListId,
            //    UserId = userId,
            //    TodoListItemSubject = newItem.TodoListItemSubject,
            //    TodoListItemIsComplete = newItem.TodoListItemIsComplete
            //});

            //return GetSingleTodoItem(user.UserId, todoListId, newid);
            return null;

        }




        public static Todo GetSingleTodoItem(Guid userId, Guid todoListId, Guid todoListItemRowId)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];
            //var item = MockDB._todoListItems.Where
            //(i => i.UserId == userId
            //      && i.TodoListItemId == todoListItemRowId
            //      && i.TodoListId == todoListId).ToList().First();

            //return new Todo()
            //{
            //    TodoListItemId = item.TodoListItemId,
            //    TodoListItemSubject = item.TodoListItemSubject,
            //    TodoListItemIsComplete = item.TodoListItemIsComplete
            //};
            return null;

        }


        public static Todo UpdateSingleTodoItem(Guid userId, Guid todoListId, Guid todoListItemId,
            Todo updatedTodoItem)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            //var itemToUpdate = MockDB._todoListItems.Where(i =>
            //        i.UserId == userId && i.TodoListId == todoListId && i.TodoListItemId == todoListItemId)
            //    .ToList().First();

            //itemToUpdate.TodoListItemIsComplete = updatedTodoItem.TodoListItemIsComplete;
            //itemToUpdate.TodoListItemSubject = updatedTodoItem.TodoListItemSubject;

            //return new Todo()
            //{
            //    TodoListItemId = itemToUpdate.TodoListItemId,
            //    TodoListItemSubject = itemToUpdate.TodoListItemSubject,
            //    TodoListItemIsComplete = itemToUpdate.TodoListItemIsComplete
            //};
            return null;

        }

        public static void DeleteSingleTodo(Guid userId, Guid todoListId, Guid todoItemId)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];
            //MockDB._todoListItems.Where(i => i.TodoListId == todoListId && i.TodoListItemId == todoItemId).ToList().ForEach(item => MockDB._todoListItems.Remove(item));

        }


    }
}
