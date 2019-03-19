using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoardMemberEntity.Data;
using webApi.Data;

namespace webApi.Pages.Boardmember
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
        public BoardMember BoardMember { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BoardMember.Add(BoardMember);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}