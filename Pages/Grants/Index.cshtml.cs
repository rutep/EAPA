using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grant.Data;
using webApi.Data;

namespace webApi.Pages.Grants
{
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public IndexModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Grant.Data.Grant> Grant { get;set; }

        public async Task OnGetAsync()
        {
            Grant = await _context.Grant.ToListAsync();
        }
    }
}
