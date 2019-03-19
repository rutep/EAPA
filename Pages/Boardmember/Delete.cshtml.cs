using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoardMemberEntity.Data;
using webApi.Data;

namespace webApi.Pages.Boardmember
{
    public class DeleteModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public DeleteModel(webApi.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoardMember = await _context.BoardMember.FindAsync(id);

            if (BoardMember != null)
            {
                _context.BoardMember.Remove(BoardMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
