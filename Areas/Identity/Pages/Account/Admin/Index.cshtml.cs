using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webApi.Areas.Identity.Pages.Account.Admin
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;
        public async Task OnGetAsync()
        {
            var audkenni = _userManager.GetUserId(User);
            var userinn = await _userManager.FindByIdAsync(audkenni);
            if (await _userManager.IsInRoleAsync(userinn, "Admin"))
            {
                String a = "";
            }
            else
            {
                String b = "";
            }
        }
    }
}