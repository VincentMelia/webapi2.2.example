using System;
using System.Collections.Generic;
using webapi22.example.dtos.DtoClasses;

namespace webapi22.example.data_access
{
    public static class DataAccess
    {
        public static Func<List<User>> AbstractGetUsers = webapi22.example.data_access.in_memory.DAL.GetUsers;

        public static Func<Guid, Guid, ToDoListWithTodos> AbstractGetTodoList = webapi22.example.data_access.in_memory.DAL.GetTodoList;
        public static Func<Guid, UserTodoLists> AbstractGetListsForUser = webapi22.example.data_access.in_memory.DAL.GetListsForUser;
        public static Func<Guid, ToDoListWithTodos, ToDoListWithTodos> AbstractCreateTodoList = webapi22.example.data_access.in_memory.DAL.CreateTodoList;
        public static Func<Guid, Guid, ToDoListWithTodos, ToDoListWithTodos> AbstractUpdateTodoList = webapi22.example.data_access.in_memory.DAL.UpdateTodoList;
        public static Action<Guid, Guid> AbstractDeleteTodoList = webapi22.example.data_access.in_memory.DAL.DeleteTodoList;
        public static Func<Guid, Guid, Todo, Todo> AbstractAddNewTodo = webapi22.example.data_access.in_memory.DAL.AddNewTodo;
        public static Func<Guid, Guid, Guid, Todo> AbstractGetSingleTodoItem = webapi22.example.data_access.in_memory.DAL.GetSingleTodoItem;
        public static Func<Guid, Guid, Guid, Todo, Todo> AbstractUpdateSingleTodoItem = webapi22.example.data_access.in_memory.DAL.UpdateSingleTodoItem;
        public static Action<Guid, Guid, Guid> AbstractDeleteSingleTodo = webapi22.example.data_access.in_memory.DAL.DeleteSingleTodo;
        
    }
}
