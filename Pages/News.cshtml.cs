using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace webApi.Pages
{
   [AllowAnonymous]
    public class NewsModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public NewsModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Grant.Data.Grant> Grant { get; set; }

        public async Task OnGetAsync()
        {
            Grant = await _context.Grant.ToListAsync();
        }
    }
}