using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Event.Data;
using webApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event.Data.Event> Event { get;set; }


        public async Task OnGetAsync()
        {
           
            Event = await _context.Event.ToListAsync();
        }
    }
}
