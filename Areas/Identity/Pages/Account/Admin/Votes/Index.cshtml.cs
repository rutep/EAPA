using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vote.Data;
using webApi.Data;

namespace webApi.Pages.Votes
{
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public IndexModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vote.Data.Vote> Vote { get;set; }

        public async Task OnGetAsync()
        {
            Vote = await _context.Vote.ToListAsync();
        }
    }
}
