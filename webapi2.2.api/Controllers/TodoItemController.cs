using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static webapi22.example.validation.RouteValidators;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;

namespace webapi2._2.api.Controllers
{
    [Route("todos")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        [HttpGet("{todoListId}/{todoListItemId}")]
        public ActionResult<Todo> Get(Guid todoListId, Guid todoListItemId)
        {
            var v = ValidatePath(todoListId, todoListItemId);
            return webapi22.example.data_access.DataAccess.AbstractGetSingleTodoItem(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

        }

        [HttpPut("{todoListId}/{todoListItemId}")]
        public object /*ActionResult<TodoListItemDtoRow>**/ Put(Guid todoListId, Guid todoListItemId, Todo updatedTodoItem)
        {
            //StatusCodes.Status406NotAcceptable
            var r = updatedTodoItem.ValidateTodoListItem();
            if (!r.Item1) return r.Item2.Select(i => i.ErrorMessage).ToList();

            return webapi22.example.data_access.DataAccess.AbstractUpdateSingleTodoItem(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId, updatedTodoItem);
        }

        [HttpDelete("{todoListId}/{todoListItemId}")]
        public void Delete(Guid todoListId, Guid todoListItemId)
        {
            webapi22.example.data_access.DataAccess.AbstractDeleteSingleTodo(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);
        }

        //[HttpPut("{todoListId}/{todoListItemId}/MarkComplete")]
        [Route("{todoListId}/{todoListItemId}/MarkComplete")]
        public object /*ActionResult<TodoListItemDtoRow>**/ Put(Guid todoListId, Guid todoListItemId)
        {        
            var todoToUpdate =
                webapi22.example.data_access.DataAccess.AbstractGetSingleTodoItem(
                    new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId);

            todoToUpdate.TodoListItemIsComplete = true;

            return webapi22.example.data_access.DataAccess.AbstractUpdateSingleTodoItem(new Guid(HttpContext.Session.GetString("UserId")), todoListId, todoListItemId, todoToUpdate);
        }

    }
}