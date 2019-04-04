using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var todoLists = MockDB._todoList.Where(l => l.UserId == userId);

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
    }
}
