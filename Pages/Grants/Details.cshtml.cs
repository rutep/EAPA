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
    public class DetailsModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public DetailsModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Grant.Data.Grant Grant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grant = await _context.Grant.FirstOrDefaultAsync(m => m.Id == id);

            if (Grant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
