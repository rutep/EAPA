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

namespace webApi.Pages.Votes
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
        public Vote.Data.Vote Vote { get; set; }

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

                Vote = await _context.Vote.FirstOrDefaultAsync(m => m.Id == id);

                if (Vote == null)
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

            Vote = await _context.Vote.FindAsync(id);

            if (Vote.Image != "")
            {
                var fileName = Path.Combine(he.WebRootPath + "\\images\\votes", Vote.Image);
                System.IO.File.Delete(fileName);
            }

            if (Vote != null)
            {
                _context.Vote.Remove(Vote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        

    }
}
