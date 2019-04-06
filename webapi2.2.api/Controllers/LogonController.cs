using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static webapi22.example.data_access.DataAccess;
using webapi22.example.dtos.DtoClasses;

namespace webapi2._2.api.Controllers
{
    [Route("todos/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        // GET: api/Logon
        [HttpGet]
        public List<User> Get()
        {
            return AbstractGetUsers();
            
        }

        [HttpGet("{UserName}")]
        public User Get(string userName)
        {
            var userlist = AbstractGetUsers();
            var validatedUser = userlist.Where(u => u.UserName.ToLower() == userName.ToLower()).ToList()[0];
            HttpContext.Session.SetString("UserId", validatedUser.UserId.ToString());
            return new User() {UserId = validatedUser.UserId, UserName = validatedUser.UserName};
        }

        // GET: api/Logon/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Logon
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Logon/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
