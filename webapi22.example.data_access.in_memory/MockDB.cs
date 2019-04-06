using System;
using System.Collections.Generic;
using webapi22.example.data_access.sql.TypedListClasses;

namespace webapi22.example.data_access.in_memory
{
    public class MockDB
    {
        public static List<UserEntityDtoRow> _userList = new List<UserEntityDtoRow>()
        {
            new UserEntityDtoRow() { UserId = Guid.NewGuid(), UserName = "Vinny"},
            new UserEntityDtoRow() { UserId = Guid.NewGuid(), UserName = "Dimitri"},
            new UserEntityDtoRow() { UserId = Guid.NewGuid(), UserName = "Jim"}
        };

        public static List<TodoListEntityDtoRow> _todoList = new List<TodoListEntityDtoRow>()
        {
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's Default List", UserId = _userList[0].UserId }

        };

        public static List<TodoListItemEntityDtoRow> _todoListItems = new List<TodoListItemEntityDtoRow>()
        {
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId }
        };

    }
}
