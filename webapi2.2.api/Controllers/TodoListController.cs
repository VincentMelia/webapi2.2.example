using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;
using static webapi22.example.data_access.DataAccess;
//using Todo = webapi22.example.data_access.TypedListClasses.Todo;

namespace webapi2._2.api.Controllers
{
    [Route("todos")]
    [ApiController]
    [LogonRequired]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public /*ActionResult<UserTodoLists>*/object Get()
        {
            var validationResults = AbstractValidateUser(new Guid(HttpContext.Session?.GetString("UserId")));

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return AbstractGetListsForUser(
                new Guid(HttpContext.Session.GetString("UserId")));
        }

        [HttpGet("{todoListId}", Name = "Get")]
        public /*ActionResult<ToDoListWithTodos>*/object Get(Guid todoListId)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractGetTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId));
        }

        [HttpPost]
        public /*ActionResult<ToDoListWithTodos>*/ object Post(ToDoListWithTodos toDoListWithTodos)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), toDoListWithTodos.TodoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractCreateTodoList(new Guid(HttpContext.Session.GetString("UserId")), toDoListWithTodos));
        }

  
        [HttpPut("{todoListId}")]
        public /*ActionResult<ToDoListWithTodos>*/object Put(Guid todoListId, [FromBody] ToDoListWithTodos updatedTodoList)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            updatedTodoList.TodoListId = todoListId;

            return Ok(AbstractUpdateTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId, updatedTodoList));
        }


        [HttpDelete("{todoListId}")]
        public /*IActionResult*/object Delete(Guid todoListId)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            AbstractDeleteTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId );

            return Ok();
        }

        [HttpPost("{todoListId}")]
        public /*ActionResult<ToDoListWithTodos>*/object Post(Guid todoListId, [FromBody] Todo newTodoItem)
        {
            var validationResults = MainValidator.Validate(
                new Guid(HttpContext.Session.GetString("UserId")), todoListId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractAddNewTodo(new Guid(HttpContext.Session.GetString("UserId")), todoListId, newTodoItem));
        }


    }
}
