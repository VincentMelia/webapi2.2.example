using System;
using NUnit.Framework;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Todo_Subject_Required()
        {
            Todo t = new Todo()
            {
                TodoListItemId = Guid.NewGuid(),
                TodoListItemIsComplete = false,
                TodoListItemSubject = ""
            };
            Assert.IsFalse(t.ValidateTodoListItem().Item1);
        
            t.TodoListItemSubject = null;
            Assert.IsFalse(t.ValidateTodoListItem().Item1);

            t.TodoListItemSubject = "abc";
            Assert.IsTrue(t.ValidateTodoListItem().Item1);
        }

        [Test]
        public void TodoList_Name_Required()
        {
            ToDoListWithTodos t = new ToDoListWithTodos()
            {
                TodoListId = Guid.NewGuid(),
                TodoListName = ""
            };
            Assert.IsFalse(t.ValidateTodoListWithTodos().Item1);

            t.TodoListName = null;
            Assert.IsFalse(t.ValidateTodoListWithTodos().Item1);

            t.TodoListName = "abc";
            Assert.IsTrue(t.ValidateTodoListWithTodos().Item1);

        }
    }
}