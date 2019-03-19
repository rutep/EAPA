using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grant.Data;
using webApi.Data;
using Microsoft.AspNetCore.Identity;
using webApi.Areas.Identity.Pages.Account.Admin;

namespace webApi.Pages.Grants
{
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<MyUser> manager;
        //Here I will create the variables that goes in to the model
        public List<MyUser> user { get; set; }

        public IndexModel(webApi.Data.ApplicationDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Grant.Data.Grant> Grant { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var audkenni = _userManager.GetUserId(User);
            var userinn = await _userManager.FindByIdAsync(audkenni);
            if (await _userManager.IsInRoleAsync(userinn, "Member"))
            {
                return Redirect("/");
            }
            //Else is for admin
            else
            {

                Grant = await _context.Grant.ToListAsync();
                return Page();
            }
        }
    }
}
