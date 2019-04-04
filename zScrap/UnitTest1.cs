using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static webapi22.example.data_access.in_memory.DAL;
using static webapi22.example.data_access.in_memory.MockDB;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.dtos.DtoClasses.ToDoListWithTodosTypes;

namespace zScrap
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tl = GetTodoList(_userList[0].UserId, _todoList[0].TodoListId);
            var u = GetListsForUser(_userList[0].UserId);

            var newList = new ToDoListWithTodos();
            newList.TodoListId = Guid.Empty;
            newList.TodoListName = "1111";
            newList.TodoListItems = new List<TodoListItem>();
            newList.TodoListItems.Add(new TodoListItem()
            {
                TodoListItemId = Guid.NewGuid(),
                TodoListItemIsComplete = false,
                TodoListItemSubject = "Subject1"
            });
            newList = CreateTodoList(_userList[0].UserId, newList);
        }

        
    }
}
