using System;
using System.Collections.Generic;
using webapi22.example.dtos.DtoClasses;

namespace webapi22.example.data_access.sql.dal
{
    public static class DAL
    {
        public static List<User> GetUsers()
        {
            //return MockDB._userList.Select(u => new User() { UserId = u.UserId, UserName = u.UserName }).ToList();
            return null;
        }

        public static ToDoListWithTodos GetTodoList(Guid userId, Guid todoListId)
        {
            //var todoList = MockDB._todoList.Where(t => t.UserId == userId && t.TodoListId == todoListId).ToList()[0];
            //var todoItems = MockDB._todoListItems.Where(t => t.TodoListId == todoListId);

            //return new ToDoListWithTodos()
            //{
            //    TodoListId = todoList.TodoListId,
            //    TodoListName = todoList.TodoListName,
            //    //TodoListItems = new List<TodoListItem>()
            //    TodoListItems = todoItems.Where(item => item.UserId == userId).Select(item => new TodoListItem()
            //    {
            //        TodoListItemId = item.TodoListItemId,
            //        TodoListItemSubject = item.TodoListItemSubject,
            //        TodoListItemIsComplete = item.TodoListItemIsComplete
            //    }).ToList()
            //};
            return null;

        }

        public static UserTodoLists GetListsForUser(Guid userId)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            //return new UserTodoLists()
            //{
            //    UserId = user.UserId,
            //    UserName = user.UserName,
            //    TodoLists = MockDB._todoList.Where(listItem => listItem.UserId == user.UserId).Select(listItem => new TodoList()
            //    {
            //        TodoListId = listItem.TodoListId,
            //        TodoListName = listItem.TodoListName
            //    }).ToList()
            //};
            return null;

        }

        public static ToDoListWithTodos CreateTodoList(Guid userId, ToDoListWithTodos newTodoListWithTodos)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            //var newTodoList = new TodoListEntityDtoRow()
            //{
            //    TodoListId = Guid.NewGuid(),
            //    TodoListName = newTodoListWithTodos.TodoListName,
            //    UserId = user.UserId
            //};

            //MockDB._todoList.Add(newTodoList);

            //newTodoListWithTodos.TodoListItems.ForEach(newItem => MockDB._todoListItems.Add(new TodoListItemEntityDtoRow()
            //{
            //    TodoListItemId = Guid.NewGuid(),
            //    TodoListId = newTodoList.TodoListId,
            //    TodoListItemSubject = newItem.TodoListItemSubject,
            //    TodoListItemIsComplete = newItem.TodoListItemIsComplete,
            //    UserId = user.UserId
            //}));

            //return GetTodoList(user.UserId,
            //    newTodoList.TodoListId);
            return null;

        }

        public static ToDoListWithTodos UpdateTodoList(Guid userId, Guid todoListId, ToDoListWithTodos updatedtDoListWithTodos)
        {
            //var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            //var todoListToUpdate = MockDB._todoList
            //    .Where(l => l.UserId == userId && l.TodoListId == updatedtDoListWithTodos.TodoListId).ToList()[0];

            //todoListToUpdate.TodoListName = updatedtDoListWithTodos.TodoListName;

            //MockDB._todoListItems.Where(i => i.TodoListId == updatedtDoListWithTodos.TodoListId).ToList()
            //    .ForEach(i => MockDB._todoListItems.Remove(i));

            //updatedtDoListWithTodos.TodoListItems.ForEach(u => MockDB._todoListItems.Add(new TodoListItemEntityDtoRow()
            //{
            //    TodoListId = todoListToUpdate.TodoListId,
            //    TodoListItemId = Guid.NewGuid(),
            //    TodoListItemSubject = u.TodoListItemSubject,
            //    TodoListItemIsComplete = u.TodoListItemIsComplete,
            //    UserId = user.UserId
            //}));

            //return GetTodoList(user.UserId, todoListToUpdate.TodoListId);
            return null;

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
