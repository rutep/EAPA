using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FAQ.Data;
using webApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace webApi.Pages
{
    [AllowAnonymous]
    public class FAQModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        public List<FAQ.Data.FAQ> FAQS;
        public FAQModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            FAQS = _context.Faq.Where(s => s.Id >= 0).ToList();  
            return Page();
        }

        [BindProperty]
        public FAQ.Data.FAQ FAQ { get; set; }
    }
}