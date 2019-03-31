using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Event.Data;
using webApi.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Boardmember
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;
        private readonly UserManager<MyUser> _userManager;

        public DeleteModel(webApi.Data.ApplicationDbContext context, IHostingEnvironment e, UserManager<MyUser> userManager)
        {
            _context = context;
            he = e;
            _userManager = userManager;
        }

        [BindProperty]
        public BoardMemberEntity.Data.BoardMember BoardMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var audkenni = _userManager.GetUserId(User);
            var userinn = await _userManager.FindByIdAsync(audkenni);
            if (await _userManager.IsInRoleAsync(userinn, "Member"))
            {
                return Redirect("/");
            }
            //Else is for admin
            else
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
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoardMember = await _context.BoardMember.FindAsync(id);

            if (BoardMember.Image != "")
            {
                var fileName = Path.Combine(he.WebRootPath + "\\images\\boardmembers", BoardMember.Image);
                System.IO.File.Delete(fileName);
            }

            if (BoardMember != null)
            {
                _context.BoardMember.Remove(BoardMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }



    }
}
