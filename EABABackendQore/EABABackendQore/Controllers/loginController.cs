using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EABABackendQore.DataManager;
using EABABackendQore.entity;
using EABABackendQore.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EABABackendQore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public IActionResult Post([FromBody] dynamic data)
        {

            string userName = data.userName;//response.userName;
            string password = data.password;//response.password;

            string userLoggInn = users.userLogin(userName,password);

            var answer = new sending { status = userLoggInn };

            if (userLoggInn == "wrong credentials")
            {
                return BadRequest(answer);
            }
            else
            {
                return Accepted(answer);
            }
        }
    }
}
        