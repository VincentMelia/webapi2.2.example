using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi22.example.data_access.sql.DaoClasses;
using static webapi22.example.validation.RouteValidators;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;
using static webapi22.example.data_access.DataAccess;
//using Todo = webapi22.example.data_access.TypedListClasses.Todo;
using static webapi22.example.validation.MainValidator;

namespace webapi2._2.api.Controllers
{
    [Route("todos")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public UserTodoLists Get()
        {
            return webapi22.example.data_access.DataAccess.AbstractGetListsForUser(new Guid(HttpContext.Session.GetString("UserId")));
        }

        [HttpGet("{todoListId}", Name = "Get")]
        public ActionResult<ToDoListWithTodos> Get(Guid todoListId)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractGetTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId));
        }

        [HttpPost]
        public ActionResult<ToDoListWithTodos> Post(ToDoListWithTodos toDoListWithTodos)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), toDoListWithTodos.TodoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractCreateTodoList(new Guid(HttpContext.Session.GetString("UserId")), toDoListWithTodos));
        }

  
        [HttpPut("{todoListId}")]
        public ActionResult<ToDoListWithTodos> Put(Guid todoListId, [FromBody] ToDoListWithTodos updatedTodoList)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            updatedTodoList.TodoListId = todoListId;

            return Ok(AbstractUpdateTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId, updatedTodoList));
        }


        [HttpDelete("{todoListId}")]
        public IActionResult Delete(Guid todoListId)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            AbstractDeleteTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId );

            return Ok();
        }

        [HttpPost("{todoListId}")]
        public ActionResult<ToDoListWithTodos> Post(Guid todoListId, [FromBody] Todo newTodoItem)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractAddNewTodo(new Guid(HttpContext.Session.GetString("UserId")), todoListId, newTodoItem));
        }


    }
}
