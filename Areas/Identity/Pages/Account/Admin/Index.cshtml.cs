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
        
        public void OnGet()
        {

        }
    }
    
}