using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FAQ.Data;
using webApi.Data;

namespace webApi.Areas.Identity.Pages.Account.Admin.FAQS
{
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public IndexModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FAQ.Data.FAQ> FAQ { get;set; }

        public async Task OnGetAsync()
        {
            FAQ = await _context.Faq.ToListAsync();
        }
    }
}
