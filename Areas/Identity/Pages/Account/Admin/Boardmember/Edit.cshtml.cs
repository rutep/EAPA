using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Boardmember
{
    public class EditModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment he;
        private readonly UserManager<MyUser> _userManager;
        public EditModel(webApi.Data.ApplicationDbContext context, IHostingEnvironment e, UserManager<MyUser> userManager)
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

        public async Task<IActionResult> OnPostAsync(string files)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Random random = new System.Random();
                int id = random.Next(0, 100000);
                IFormFile file = HttpContext.Request.Form.Files[0];
                var fileName = Path.Combine(he.WebRootPath + "\\images\\events", id + file.FileName);
                BoardMember.Image = id + file.FileName;
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var original_data = _context.BoardMember.AsNoTracking().Where(P => P.Id == BoardMember.Id).FirstOrDefault();

                if (original_data.Image != "")
                {
                    var fileNam = Path.Combine(he.WebRootPath + "\\images\\events", original_data.Image);
                    System.IO.File.Delete(fileNam);
                }
            }
            else
            {
                BoardMember.Image = "";
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
