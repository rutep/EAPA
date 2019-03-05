using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webApi.Data;

namespace webApi.Areas.Identity.Pages.Account.Admin
{
    public class ManageUsersModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<MyUser> manager;
        //Here I will create the variables that goes in to the model
        public List<MyUser> user { get; set; }
        public ManageUsersModel(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            // Find the users in that role
                         
                 user = _userManager.Users.ToList();
                
               
            return Page();
        }
    }
}