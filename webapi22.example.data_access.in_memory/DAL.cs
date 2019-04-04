using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webapi22.example.dtos;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.dtos.DtoClasses.ToDoListWithTodosTypes;

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
                TodoListItems = new List<TodoListItem>()
            };

        }
    }
}
