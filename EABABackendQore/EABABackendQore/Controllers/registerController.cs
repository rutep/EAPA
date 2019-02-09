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
    public class registerController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] dynamic data)
        {

            string userName = data.userName;
            string password = data.password;
            string firstName = data.firstname;
            string middleName = data.middlename;
            string lastName = data.lastname;
            string email = data.email;
            string other_email = data.other_email;
            string phone = data.phone;
            string other_phone = data.other_phone;
            string affiliation = data.affiliation;
            string postcode = data.postcode;
            string region = data.region;
            string city = data.city;
            string country = data.country;
            string member_type = data.member_type;
            string repeatPassword = data.repeatPassword;
            string address = data.address;
            string other_address = data.other_address;
            var answer = new sending { status = "user already exist" };
            bool userExist = users.userNameExist(userName);
            if (password != repeatPassword)
            {
                answer = new sending { status = "The passwords are not the same" };
                return BadRequest(answer);
            }
            if (userExist == true)
            {
                return BadRequest(answer);
            }
            else
            {
                users.createUser(userName, password, firstName, middleName, lastName, email, other_email, phone, other_phone, affiliation, postcode, region,
                                 city, country, member_type, repeatPassword, address, other_address);
                answer = new sending { status = "user Created" };
                return Accepted(answer);
            }
        }
    }
}