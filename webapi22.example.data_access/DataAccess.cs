using System;
using System.Collections.Generic;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.data_access.sql.dal;

namespace webapi22.example.data_access
{
    
    public static class DataAccess
    {
        public static readonly int dataaccesstype = 0;

        public static Func<List<User>> AbstractGetUsers;
        public static Func<Guid, Guid, ToDoListWithTodos> AbstractGetTodoList;
        public static Func<Guid, UserTodoLists> AbstractGetListsForUser;
        public static Func<Guid, ToDoListWithTodos, ToDoListWithTodos> AbstractCreateTodoList;
        public static Func<Guid, Guid, ToDoListWithTodos, ToDoListWithTodos> AbstractUpdateTodoList;
        public static Action<Guid, Guid> AbstractDeleteTodoList;
        public static Func<Guid, Guid, Todo, Todo> AbstractAddNewTodo;
        public static Func<Guid, Guid, Guid, Todo> AbstractGetSingleTodoItem;
        public static Func<Guid, Guid, Guid, Todo, Todo> AbstractUpdateSingleTodoItem;
        public static Action<Guid, Guid, Guid> AbstractDeleteSingleTodo;


        static DataAccess()
        {
            if (dataaccesstype == 0)
            {
                AbstractGetUsers = in_memory.DAL.GetUsers;
                AbstractGetTodoList = in_memory.DAL.GetTodoList;
                AbstractGetListsForUser = in_memory.DAL.GetListsForUser;
                AbstractCreateTodoList = in_memory.DAL.CreateTodoList;
                AbstractUpdateTodoList = in_memory.DAL.UpdateTodoList;
                AbstractDeleteTodoList = in_memory.DAL.DeleteTodoList;
                AbstractAddNewTodo = in_memory.DAL.AddNewTodo;
                AbstractGetSingleTodoItem = in_memory.DAL.GetSingleTodoItem;
                AbstractUpdateSingleTodoItem = in_memory.DAL.UpdateSingleTodoItem;
                AbstractDeleteSingleTodo = in_memory.DAL.DeleteSingleTodo;
            }
            else if(dataaccesstype == 1)
            {

            }
            else
            {
                throw new Exception("Wrong data access configuration.");
            }


        }
    }
}
