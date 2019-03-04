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
        public ManageUsersModel(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            // Find the users in that role
            try
            {
                var roleUsers = _userManager.Users.ToList();
                var user = await _userManager.FindByEmailAsync("johndoe@email.com");
            }
            catch
            {
                int a = 4;
            }
            return Page();
        }
    }
}