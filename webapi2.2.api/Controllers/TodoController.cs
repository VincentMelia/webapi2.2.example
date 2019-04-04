﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi22.example.data_access.in_memory;
using static webapi22.example.data_access.in_memory.DAL;
using static webapi22.example.data_access.in_memory.MockDB;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.dtos.DtoClasses.ToDoListWithTodosTypes;
using webapi22.example.dtos.DtoClasses.UserTodoListsTypes;

namespace webapi2._2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // GET: api/Todo
        [HttpGet]
        public UserTodoLists Get()
        {
            // return new string[] { "value1", "value2" };
            HttpContext.Session.SetString("UserId", "dfdfdfdfd");
            return GetListsForUser(MockDB._userList[0].UserId);
        }

        // GET: api/Todo/5
        [HttpGet("{todoListId}", Name = "Get")]
        public ToDoListWithTodos Get(Guid todoListId)
        {
            var u = HttpContext.Session.GetString("UserId");
            return GetTodoList(MockDB._userList[0].UserId, todoListId);
        }

        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var u = HttpContext.Session.GetString("UserId");

        }

        [HttpPost]
        public ToDoListWithTodos Post(ToDoListWithTodos toDoListWithTodos)
        {
            return CreateTodoList(MockDB._userList[0].UserId, toDoListWithTodos);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
