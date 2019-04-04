using Microsoft.VisualStudio.TestTools.UnitTesting;
using static webapi22.example.data_access.in_memory.DAL;
using static webapi22.example.data_access.in_memory.MockDB;

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
        }

        
    }
}
