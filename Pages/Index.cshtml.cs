using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace webApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public IndexModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event.Data.Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
