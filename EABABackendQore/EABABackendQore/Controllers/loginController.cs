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
        public async Task<IActionResult> Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<register>(body);
            string userName = response.userName;
            string password = response.password;

            string userLoggInn = users.userLogin(userName, password);

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
        