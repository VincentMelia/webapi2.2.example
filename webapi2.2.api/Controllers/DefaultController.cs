using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi2._2.api.Controllers
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [Route("/")]
        public void Any()
        {
            HttpContext.Response.Redirect("/todos/logon");
        }
    }
}