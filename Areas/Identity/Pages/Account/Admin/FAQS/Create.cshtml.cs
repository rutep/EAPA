using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FAQ.Data;
using webApi.Data;

namespace webApi.Areas.Identity.Pages.Account.Admin.FAQS
{
    public class CreateModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public CreateModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FAQ.Data.FAQ FAQ { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Faq.Add(FAQ);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}