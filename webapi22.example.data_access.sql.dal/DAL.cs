using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.data_access.sql.EntityClasses;
using webapi22.example.data_access.sql.CollectionClasses;
using webapi22.example.data_access.sql.FactoryClasses;
using webapi22.example.data_access.sql.HelperClasses;
using webapi22.example.data_access.sql.DaoClasses;
using webapi22.example.dtos.Persistence;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using webapi22.example.dtos.DtoClasses.ToDoListWithTodosTypes;
using IsolationLevel = System.Data.IsolationLevel;
using PostSharp.Patterns.Caching;
using PostSharp.Patterns.Caching.Backends;

namespace webapi22.example.data_access.sql.dal
{
    public static class DAL
    {
        public static void InitCaching()
        {
            CachingServices.DefaultBackend = new MemoryCachingBackend();
        }

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

        }

        public static List<Tuple<bool, string>> ValidateUser(Guid userId)
        {
            var qf = new QueryFactory();
            var userExistsQuery = qf.Create().Select(UserFields.UserId).Where(UserFields.UserId.Equal(userId));
            var userExists = new TypedListDAO().FetchQuery(userExistsQuery).Any();

            var validationResults = new List<Tuple<bool, string>>();

            validationResults.Add(new Tuple<bool, string>(userExists, !userExists ? "User doesn't exist." : string.Empty));

            return validationResults;

        }


        public static List<User> GetUsers()
        {
            var qf = new QueryFactory();

            var usersQuery = qf.Create().Select<User, UserFields>();

            var userList = new TypedListDAO().FetchQuery(usersQuery);

            return userList;
        }
        
        public static ToDoListWithTodos GetTodoList(Guid userId, Guid todoListId)
        {
            var qf = new QueryFactory();
            
            var todolist = qf.TodoList
                .Where(TodoListFields.UserId.Equal(userId)
                    .And(TodoListFields.TodoListId.Equal(todoListId))
                )
                .Select(() => new ToDoListWithTodos()
                    {
                        TodoListId = TodoListFields.TodoListId.ToValue<Guid>(),
                        TodoListName = TodoListFields.TodoListName.ToValue<string>(),
                        TodoListItems = (List<TodoListItem>) qf.TodoListItem
                            .CorrelatedOver(TodoListItemEntity.Relations.TodoListEntityUsingTodoListId)
                            .Where(TodoListItemFields.TodoListItemIsComplete.Equal(false))
                            .Select(() => new TodoListItem()
                            {
                                TodoListItemId = TodoListItemFields.TodoListItemId.ToValue<Guid>(),
                                TodoListItemSubject = TodoListItemFields.TodoListItemSubject.ToValue<string>(),
                                TodoListItemIsComplete = TodoListItemFields.TodoListItemIsComplete.ToValue<bool>()
                            }).ToResultset()
                    }
                );
            
            var entirelist = new TypedListDAO().FetchQuery(todolist).Single();
            return entirelist;

        }
        
        public static UserTodoLists GetListsForUser(Guid userId)
        {
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
                //todo can put UpdateToDo() extension here in place of manual code
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

        public static ToDoListWithTodos UpdateTodoList(Guid userId, Guid todoListId,
            ToDoListWithTodos updatedtDoListWithTodos)
        {
            var uow = new UnitOfWork();

            var listToUpdate = new QueryFactory().TodoList
                .Where(TodoListFields.UserId.Equal(userId).And(TodoListFields.TodoListId.Equal(todoListId)))
                .GetFirst();

            listToUpdate.UpdateFromToDoListWithTodos(updatedtDoListWithTodos);

            uow.AddForSave(listToUpdate);

            var itemsToDelete = new TodoListItemCollection()
                .GetMulti(new QueryFactory().TodoListItem
                    .Where(TodoListItemFields.TodoListId.Equal(todoListId))
                );

            uow.AddCollectionForDelete(itemsToDelete);

            foreach (var updatedItem in updatedtDoListWithTodos.TodoListItems)
            {
                var itemToUpdate =
                    listToUpdate.TodoListItems.Where(x => x.TodoListItemId == updatedItem.TodoListItemId)
                        .SingleOrDefault() ?? listToUpdate.TodoListItems.AddNew();

                itemToUpdate.TodoListId = listToUpdate.TodoListId;
                if (itemToUpdate.IsNew)
                    itemToUpdate.TodoListItemId = Guid.NewGuid();

                itemToUpdate.TodoListItemSubject = updatedItem.TodoListItemSubject;
                itemToUpdate.TodoListItemIsComplete = updatedItem.TodoListItemIsComplete;

                uow.AddForSave(itemToUpdate);
            }

            uow.Commit(new HelperClasses.Transaction(IsolationLevel.ReadCommitted, "UpdateTodoList UOW"), true);

            return GetTodoList(userId, todoListId);
        }

        public static void DeleteTodoList(Guid userId, Guid todoListId)
        {
            var qf = new QueryFactory();
            var listToDelete = qf.TodoList.Where(TodoListFields.UserId.Equal(userId)
                .And(TodoListFields.TodoListId.Equal(todoListId))).GetFirst();

            listToDelete.Delete();
        }


        public static Todo AddNewTodo(Guid userId, Guid todoListId, dtos.DtoClasses.Todo newItem)
        {
            var qf = new QueryFactory();
            var newTodo = new TodoListItemEntity();
            newTodo.UpdateFromTodo(newItem);
            newTodo.TodoListItemId = Guid.NewGuid();
            newTodo.TodoListId = todoListId;
            newTodo.Save(true);

            return GetSingleTodoItem(userId, todoListId, newTodo.TodoListItemId);
        }




        public static Todo GetSingleTodoItem(Guid userId, Guid todoListId, Guid todoListItemRowId)
        {
            var qf = new QueryFactory();
            return qf.TodoListItem
                .From(QueryTarget.InnerJoin(TodoListItemEntity.Relations.TodoListEntityUsingTodoListId))
                .Where(TodoListFields.UserId.Equal(userId)
                    .And(TodoListItemFields.TodoListId.Equal(todoListId))
                    .And(TodoListItemFields.TodoListItemId.Equal(todoListItemRowId))
                ).GetFirst().ProjectToTodo();

        }


        public static Todo UpdateSingleTodoItem(Guid userId, Guid todoListId, Guid todoListItemId,
            Todo updatedTodoItem)
        {
            var qf = new QueryFactory();

            var itemToUpdate = qf.TodoListItem
                .From(QueryTarget.InnerJoin(qf.TodoList).On(TodoListItemFields.TodoListId.Equal(TodoListFields.TodoListId)))
                .Where(TodoListFields.UserId.Equal(userId)
                    .And(TodoListItemFields.TodoListId.Equal(todoListId)
                        .And(TodoListItemFields.TodoListItemId.Equal(todoListItemId))
                    )).GetFirst();

            itemToUpdate.UpdateFromTodo(updatedTodoItem);
            itemToUpdate.TodoListItemId = todoListItemId;//todo is this even needed?
            itemToUpdate.Save(true);

            return GetSingleTodoItem(userId,todoListId,itemToUpdate.TodoListItemId);

        }

        public static void DeleteSingleTodo(Guid userId, Guid todoListId, Guid todoItemId)
        {
            var qf = new QueryFactory();

            var itemToDelete = qf.TodoListItem.From(QueryTarget.InnerJoin(qf.TodoList)
                    .On(TodoListFields.TodoListId.Equal(TodoListItemFields.TodoListId)))
                .Where(TodoListFields.UserId.Equal(userId)
                    .And(TodoListItemFields.TodoListId.Equal(todoListId))
                    .And(TodoListItemFields.TodoListItemId.Equal(todoItemId))
                ).GetFirst();

            itemToDelete.Delete();

        }


    }
}
