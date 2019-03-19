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
    public class DeleteModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public DeleteModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vote.Data.Vote Vote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vote = await _context.Vote.FirstOrDefaultAsync(m => m.Id == id);

            if (Vote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vote = await _context.Vote.FindAsync(id);

            if (Vote != null)
            {
                _context.Vote.Remove(Vote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
