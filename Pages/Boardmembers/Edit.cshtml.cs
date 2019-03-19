using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoardMemberEntity.Data;
using webApi.Data;

namespace webApi.Pages.Boardmembers
{
    public class EditModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public EditModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BoardMember BoardMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoardMember = await _context.BoardMember.FirstOrDefaultAsync(m => m.Id == id);

            if (BoardMember == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BoardMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardMemberExists(BoardMember.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BoardMemberExists(int id)
        {
            return _context.BoardMember.Any(e => e.Id == id);
        }
    }
}
