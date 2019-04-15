using System;
using System.Collections.Generic;
using webapi22.example.dtos.DtoClasses;
//using webapi22.example.data_access.sql.dal;

namespace webapi22.example.data_access
{
    
    public static class DataAccess
    {
        public static readonly int dataaccesstype = 0;

        //validators
        public static Func<Guid, Guid, List<Tuple<bool, string>>> AbstractValidatePathForList;
        public static Func<Guid, Guid, Guid, List<Tuple<bool, string>>> AbstractValidatePathForListAndItem;
        public static Func<Guid, List<Tuple<bool, string>>> AbstractValidateUser;


        //data access
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
                AbstractValidatePathForList = in_memory.DAL.ValidatePath;
                AbstractValidatePathForListAndItem = in_memory.DAL.ValidatePath;
                AbstractValidateUser = in_memory.DAL.ValidateUser;

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
                AbstractValidatePathForList = sql.dal.DAL.ValidatePath;
                AbstractValidatePathForListAndItem = sql.dal.DAL.ValidatePath;
                AbstractValidateUser = sql.dal.DAL.ValidateUser;

                AbstractGetUsers = sql.dal.DAL.GetUsers;
                AbstractGetTodoList = sql.dal.DAL.GetTodoList;
                AbstractGetListsForUser = sql.dal.DAL.GetListsForUser;
                AbstractCreateTodoList = sql.dal.DAL.CreateTodoList;
                AbstractUpdateTodoList = sql.dal.DAL.UpdateTodoList;
                AbstractDeleteTodoList = sql.dal.DAL.DeleteTodoList;
                AbstractAddNewTodo = sql.dal.DAL.AddNewTodo;
                AbstractGetSingleTodoItem = sql.dal.DAL.GetSingleTodoItem;
                AbstractUpdateSingleTodoItem = sql.dal.DAL.UpdateSingleTodoItem;
                AbstractDeleteSingleTodo = sql.dal.DAL.DeleteSingleTodo;
            }
            else
            {
                throw new Exception("Wrong data access configuration.");
            }


        }
    }
}
