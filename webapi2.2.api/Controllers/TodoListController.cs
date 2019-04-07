using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static webapi22.example.validation.RouteValidators;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;
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
        public ToDoListWithTodos Get(Guid todoListId)
        {
            var v = ValidatePath(todoListId);
            return webapi22.example.data_access.DataAccess.AbstractGetTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId);
        }

        [HttpPost]
        public ToDoListWithTodos Post(ToDoListWithTodos toDoListWithTodos)
        {
            return webapi22.example.data_access.DataAccess.AbstractCreateTodoList(new Guid(HttpContext.Session.GetString("UserId")), toDoListWithTodos);
        }

  
        [HttpPut("{todoListId}")]
        public object /*ToDoListWithTodos**/ Put(Guid todoListId, [FromBody] ToDoListWithTodos updatedTodoList)
        {
            var r = updatedTodoList.ValidateTodoListWithTodos();
            if (!r.Item1) return r.Item2.Select(i => i.ErrorMessage).ToList();

            updatedTodoList.TodoListId = todoListId;
            return webapi22.example.data_access.DataAccess.AbstractUpdateTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId, updatedTodoList);
        }


        [HttpDelete("{todoListId}")]
        public void Delete(Guid todoListId)
        {
            webapi22.example.data_access.DataAccess.AbstractDeleteTodoList(new Guid(HttpContext.Session.GetString("UserId")), todoListId );
        }

        [HttpPost("{todoListId}")]
        public /*TodoListItemDtoRow**/ object Post(Guid todoListId, [FromBody] Todo newTodoItem)
        {
            var r = newTodoItem.ValidateTodoListItem();
            if (!r.Item1) return r.Item2.Select(i => i.ErrorMessage).ToList();

            return webapi22.example.data_access.DataAccess.AbstractAddNewTodo(new Guid(HttpContext.Session.GetString("UserId")), todoListId, newTodoItem);
        }


    }
}
