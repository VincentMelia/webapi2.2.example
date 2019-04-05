using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webapi22.example.data_access.TypedListClasses;
using webapi22.example.dtos;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.dtos.DtoClasses.ToDoListWithTodosTypes;
using webapi22.example.dtos.DtoClasses.UserTodoListsTypes;

namespace webapi22.example.data_access.in_memory
{
    public static class DAL
    {
        public static ToDoListWithTodos GetTodoList(Guid userId, Guid todoListId)
        {
            var todoList = MockDB._todoList.Where(t => t.UserId == userId && t.TodoListId == todoListId).ToList()[0];
            var todoItems = MockDB._todoListItems.Where(t => t.TodoListId == todoListId);

            return new ToDoListWithTodos()
            {
                TodoListId = todoList.TodoListId,
                TodoListName = todoList.TodoListName,
                //TodoListItems = new List<TodoListItem>()
                TodoListItems = todoItems.Select(item => new TodoListItem()
                {
                    TodoListItemId = item.TodoListItemId,
                    TodoListItemSubject = item.TodoListItemSubject,
                    TodoListItemIsComplete = item.TodoListItemIsComplete
                }).ToList()
            };

        }

        public static UserTodoLists GetListsForUser(Guid userId)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            return new UserTodoLists()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                TodoLists = MockDB._todoList.Select(listItem => new TodoList()
                {
                    TodoListId = listItem.TodoListId,
                    TodoListName = listItem.TodoListName
                }).ToList()
            };
        }

        public static ToDoListWithTodos CreateTodoList(Guid userId, ToDoListWithTodos newTodoListWithTodos)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            var newTodoList = new TodoListDtoRow()
            {
                TodoListId = Guid.NewGuid(),
                TodoListName = newTodoListWithTodos.TodoListName,
                UserId = user.UserId
            };

            MockDB._todoList.Add(newTodoList);

            newTodoListWithTodos.TodoListItems.ForEach(newItem => MockDB._todoListItems.Add(new TodoListItemDtoRow()
            {
                TodoListItemId = Guid.NewGuid(),
                TodoListId = newTodoList.TodoListId,
                TodoListItemSubject = newItem.TodoListItemSubject,
                TodoListItemIsComplete = newItem.TodoListItemIsComplete
            }));

            return GetTodoList(MockDB._userList.Where(u => u.UserId == userId).ToList()[0].UserId,
                newTodoList.TodoListId);
        }

        public static ToDoListWithTodos UpdateTodoList(Guid userId, ToDoListWithTodos updatedtDoListWithTodos)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            var todoListToUpdate = MockDB._todoList
                .Where(l => l.UserId == userId && l.TodoListId == updatedtDoListWithTodos.TodoListId).ToList()[0];

            todoListToUpdate.TodoListName = updatedtDoListWithTodos.TodoListName;

            MockDB._todoListItems.Where(i => i.TodoListId == updatedtDoListWithTodos.TodoListId).ToList()
                .ForEach(i => MockDB._todoListItems.Remove(i));

            updatedtDoListWithTodos.TodoListItems.ForEach(u => MockDB._todoListItems.Add(new TodoListItemDtoRow()
            {
                TodoListId = todoListToUpdate.TodoListId,
                TodoListItemId = Guid.NewGuid(),
                TodoListItemSubject = u.TodoListItemSubject,
                TodoListItemIsComplete = u.TodoListItemIsComplete
            }));

            return GetTodoList(user.UserId, todoListToUpdate.TodoListId);
        }

        public static void DeleteTodoList(Guid userId, Guid todoListId)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            MockDB._todoListItems.Where(i => i.TodoListId == todoListId).ToList().ForEach(item => MockDB._todoListItems.Remove(item));
            MockDB._todoList.Where(l => l.TodoListId == todoListId).ToList().ForEach(list => MockDB._todoList.Remove(list));
        }

        public static void AddNewTodo(Guid userId, Guid todoListId, TodoListItemDtoRow newItem)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            var list = MockDB._todoList.Where(l => l.TodoListId == todoListId).ToList()[0];

            var newid = Guid.NewGuid();

            MockDB._todoListItems.Add(new TodoListItemDtoRow() { TodoListItemId = newid, TodoListId = list.TodoListId
                , TodoListItemSubject = newItem.TodoListItemSubject, TodoListItemIsComplete = newItem.TodoListItemIsComplete});
        }

        public static TodoListItemDtoRow GetSingleTodoItem(Guid userId, Guid todoListId, Guid todoListItemRowId)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];
            var item = MockDB._todoListItems.Where
                (i => i.UserId == userId 
                      && i.TodoListItemId == todoListItemRowId
                      && i.TodoListId == todoListId).ToList().First();

            return item;
        }

        public static TodoListItemDtoRow UpdateSingleTodoItem(Guid userId, Guid todoListId,
            TodoListItemDtoRow updatedTodoItem)
        {
            var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

            var itemToUpdate = MockDB._todoListItems.Where(i =>
                    i.UserId == userId && i.TodoListId == todoListId && i.TodoListItemId == updatedTodoItem.TodoListItemId)
                .ToList().First();

            itemToUpdate.TodoListItemIsComplete = updatedTodoItem.TodoListItemIsComplete;
            itemToUpdate.TodoListItemSubject = updatedTodoItem.TodoListItemSubject;

            return itemToUpdate;
        }

        //public static ToDoListWithTodos UpdateTodoList(Guid userId, ToDoListWithTodos updatedtDoListWithTodos)
        //{
        //    var user = MockDB._userList.Where(u => u.UserId == userId).ToList()[0];

        //    var todoListToUpdate = MockDB._todoList
        //        .Where(l => l.UserId == userId && l.TodoListId == updatedtDoListWithTodos.TodoListId).ToList()[0];

        //    todoListToUpdate.TodoListName = updatedtDoListWithTodos.TodoListName;

        //    MockDB._todoListItems.Where(i => i.TodoListId == updatedtDoListWithTodos.TodoListId).ToList()
        //        .ForEach(i => MockDB._todoListItems.Remove(i));

        //    updatedtDoListWithTodos.TodoListItems.ForEach(u => MockDB._todoListItems.Add(new TodoListItemDtoRow()
        //    {
        //        TodoListId = todoListToUpdate.TodoListId,
        //        TodoListItemId = Guid.NewGuid(),
        //        TodoListItemSubject = u.TodoListItemSubject,
        //        TodoListItemIsComplete = u.TodoListItemIsComplete
        //    }));

        //    return GetTodoList(user.UserId, todoListToUpdate.TodoListId);
        //}

    }
}
