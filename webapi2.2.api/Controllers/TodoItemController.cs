using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;
using static webapi22.example.data_access.DataAccess;

namespace webapi2._2.api.Controllers
{
    [Route("todos")]
    [ApiController]
    [LogonRequired]
    public class TodoItemController : ControllerBase
    {
        [HttpGet("{todoListId}/{todoListItemId}")]
        public object /*ActionResult<Todo>*/ Get(Guid todoListId, Guid todoListItemId)
        {
            var validationResults = MainValidator.Validate(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            return Ok(AbstractGetSingleTodoItem(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId));
        }

        [HttpPut("{todoListId}/{todoListItemId}")]
        public object /*ActionResult<Todo>*/ Put(Guid todoListId, Guid todoListItemId, Todo updatedTodoItem)
        {
            var validationResults = MainValidator.Validate(updatedTodoItem,
                new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());


            return Ok(AbstractUpdateSingleTodoItem(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId, updatedTodoItem));
        }

        [HttpDelete("{todoListId}/{todoListItemId}")]
        public object /*IActionResult*/ Delete(Guid todoListId, Guid todoListItemId)
        {
            var validationResults = MainValidator.Validate(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            AbstractDeleteSingleTodo(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

            return Ok();
        }

        [Route("{todoListId}/{todoListItemId}/MarkComplete")]
        public object /*ActionResult<Todo>*/ Put(Guid todoListId, Guid todoListItemId)
        {
            var validationResults = MainValidator.Validate(new Guid(HttpContext.Session.GetString("UserId")),
                todoListId, todoListItemId);

            if (validationResults.Any(x => !x.Item1))
                return BadRequest(validationResults.Where(x => !x.Item1).ToList());

            var todoToUpdate =
                AbstractGetSingleTodoItem(
                    new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

            todoToUpdate.TodoListItemIsComplete = true;

            return Ok(AbstractUpdateSingleTodoItem(new Guid(HttpContext.Session.GetString("UserId")), todoListId,
                todoListItemId, todoToUpdate));
        }

    }
}