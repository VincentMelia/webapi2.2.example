using System;
using System.Collections.Generic;
using webapi22.example.data_access.sql.TypedListClasses;

namespace webapi22.example.data_access.in_memory
{
    public class MockDB
    {
        public static List<UserEntityDtoRow> _userList = new List<UserEntityDtoRow>()
        {
            new UserEntityDtoRow() { UserId = new Guid("69b53ae6-a02e-4a6e-9d10-7b69498089e1"), UserName = "Vinny"},
            new UserEntityDtoRow() { UserId = new Guid("2157e527-2fdc-4d7a-b3af-9b3ddf3f10aa"), UserName = "Dimitri"},
            new UserEntityDtoRow() { UserId = new Guid("2e4ecd52-a9f1-4b38-ae2c-d07205704fd1"), UserName = "Jim"}
        };

        public static List<TodoListEntityDtoRow> _todoList = new List<TodoListEntityDtoRow>()
        {
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 1", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 2", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 3", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 4", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 5", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 6", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 7", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 8", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 9", UserId = _userList[0].UserId },
            new TodoListEntityDtoRow() {TodoListId = Guid.NewGuid(), TodoListName = "Vinny's List 10", UserId = _userList[0].UserId }

        };

        public static List<TodoListItemEntityDtoRow> _todoListItems = new List<TodoListItemEntityDtoRow>()
        {
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 1", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 2", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 3", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 4", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 5", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 6", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 7", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 8", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId },
            new TodoListItemEntityDtoRow() { TodoListItemId = Guid.NewGuid(), TodoListItemSubject = "Subject 9", TodoListItemIsComplete = false, TodoListId = _todoList[0].TodoListId, UserId = _userList[0].UserId }
        };

    }
}
