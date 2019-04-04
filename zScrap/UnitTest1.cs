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
            var r = GetTodoList(_userList[0].UserId, _todoList[0].TodoListId);
        }

        
    }
}
