using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event.Data;
using webApi.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Events
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
        public Event.Data.Event Event { get; set; }
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

                Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

                if (Event == null)
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
                Event.Image = id + file.FileName;
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var original_data = _context.Event.AsNoTracking().Where(P => P.Id == Event.Id).FirstOrDefault();
                
                if (original_data.Image != "")
                {
                    var fileNam = Path.Combine(he.WebRootPath + "\\images\\events", original_data.Image);
                    System.IO.File.Delete(fileNam);
                }
            }
            else
            {
                Event.Image = "";
            }

            _context.Attach(Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.Id))
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

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
