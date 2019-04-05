using System;
using System.Collections.Generic;
using webapi22.example.data_access.TypedListClasses;

namespace webapi22.example.data_access.in_memory
{
    public class MockDB
    {
        public static List<UserDtoRow> _userList = new List<UserDtoRow>()
        {
            new UserDtoRow() { UserId = Guid.NewGuid(), UserName = "Vinny"},
            new UserDtoRow() { UserId = Guid.NewGuid(), UserName = "Dimitri"},
            new UserDtoRow() { UserId = Guid.NewGuid(), UserName = "Jim"}
        };

        public static List<TodoListDtoRow> _todoList = new List<TodoListDtoRow>()
        {
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId }

        };

        public static List<TodoListItemDtoRow> _todoListItems = new List<TodoListItemDtoRow>()
        {
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId }
        };

    }
}
