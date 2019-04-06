using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi22.example.data_access.in_memory;
using webapi22.example.data_access.sql.TypedListClasses;
using static webapi22.example.data_access.in_memory.DAL;
using static webapi22.example.data_access.in_memory.MockDB;
using static webapi22.example.validation.RouteValidators;
using webapi22.example.data_access.sql;
using webapi22.example.data_access.sql.EntityClasses;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.dtos.DtoClasses.ToDoListWithTodosTypes;
using webapi22.example.dtos.DtoClasses.UserTodoListsTypes;
using webapi22.example.validation;
//using Todo = webapi22.example.data_access.TypedListClasses.Todo;

namespace webapi2._2.api.Controllers
{
    //[Route("api/[controller]")]
    [Route("todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // GET: api/Todo
        [HttpGet]
        public UserTodoLists Get() //UserTodoLists
        {
            
            //return new string[] { "value1", "value2" };
            HttpContext.Session.SetString("UserId", "dfdfdfdfd");
            return GetListsForUser(MockDB._userList[0].UserId);
        }

        // GET: api/Todo/5
        [HttpGet("{todoListId}", Name = "Get")]
        public ToDoListWithTodos Get(Guid todoListId)
        {
            var v = ValidatePath(todoListId);
            var u = HttpContext.Session.GetString("UserId");
            return GetTodoList(MockDB._userList[0].UserId, todoListId);
        }


        // POST: api/Todo
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    var u = HttpContext.Session.GetString("UserId");

        //}

        [HttpPost]
        public ToDoListWithTodos Post(ToDoListWithTodos toDoListWithTodos)
        {
            return CreateTodoList(MockDB._userList[0].UserId, toDoListWithTodos);
        }

        // PUT: api/Todo/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        [HttpPut("{todoListId}")]
        public object /*ToDoListWithTodos**/ Put(Guid todoListId, [FromBody] ToDoListWithTodos updatedTodoList)
        {
            var r = updatedTodoList.ValidateTodoListWithTodos();
            if (!r.Item1) return r.Item2.Select(i => i.ErrorMessage).ToList();

            updatedTodoList.TodoListId = todoListId;
            return UpdateTodoList(MockDB._userList[0].UserId, updatedTodoList);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{todoListId}")]
        public void Delete(Guid todoListId)
        {
            DeleteTodoList(MockDB._userList[0].UserId, todoListId );
        }

        [HttpPost("{todoListId}")]
        public /*TodoListItemDtoRow**/ object Post(Guid todoListId, [FromBody] Todo newTodoItem)
        {
            var r = newTodoItem.ValidateTodoListItem();
            if (!r.Item1) return r.Item2.Select(i => i.ErrorMessage).ToList();

            return AddNewTodo(MockDB._userList[0].UserId, todoListId, newTodoItem);
        }


        [HttpGet("{todoListId}/{todoListItemId}")]
        public ActionResult<Todo> Get(Guid todoListId, Guid todoListItemId)
        {
            var v = ValidatePath(todoListId, todoListItemId);
            return GetSingleTodoItem(MockDB._userList[0].UserId, todoListId, todoListItemId);
            
        }

        [HttpPut("{todoListId}/{todoListItemId}")]
        public object /*ActionResult<TodoListItemDtoRow>**/ Put(Guid todoListId, Guid todoListItemId, Todo updatedTodoItem)
        {
            //StatusCodes.Status406NotAcceptable
            var r = updatedTodoItem.ValidateTodoListItem();
            if (!r.Item1) return  r.Item2.Select(i => i.ErrorMessage).ToList();

            return UpdateSingleTodoItem(MockDB._userList[0].UserId, todoListId, todoListItemId, updatedTodoItem);
        }

        [HttpDelete("{todoListId}/{todoListItemId}")]
        public void Delete(Guid todoListId, Guid todoListItemId)
        {
            //DeleteTodoList(MockDB._userList[0].UserId, todoListId);
            DeleteSingleTodo(MockDB._userList[0].UserId, todoListId, todoListItemId);
        }

    }
}
