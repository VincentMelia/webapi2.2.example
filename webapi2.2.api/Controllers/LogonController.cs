using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using static webapi22.example.data_access.DataAccess;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.validation;

namespace webapi2._2.api.Controllers
{
    [Route("todos/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        //base route here. Answer on anything.
        public List<User> Get()
        {
            return AbstractGetUsers(); 
        }

        [Route("{UserName}")] //answer on anything.
        public User Get(string userName)
        {
            var userlist = AbstractGetUsers();

            var validatedUser = userlist.Where(u => u.UserName.ToLower() == userName.ToLower()).ToList()[0];
            HttpContext.Session.SetString("UserId", validatedUser.UserId.ToString());
            return new User() {UserId = validatedUser.UserId, UserName = validatedUser.UserName};
        }

    }
}
