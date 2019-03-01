using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webApi.Areas.Identity.Pages.Account.Admin
{
    public class ManageUsersModel : PageModel
    {
        public void OnGet()
        {
            using (var context = new YourContext())
            {
                return await UserManager.Users.ToListAsync();
            }
        }
    }
}