using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vote.Data;
using webApi.Data;

namespace webApi.Pages.Votes
{
    public class CreateModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public CreateModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vote.Data.Vote Vote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Random random = new System.Random();
                int id = random.Next(0, 100000);
                IFormFile file = HttpContext.Request.Form.Files[0];
                var fileName = Path.Combine(he.WebRootPath + "\\images\\votes", id + file.FileName);
                Vote.Image = id + file.FileName;

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            else
            {
                Vote.Image = "";
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vote.Add(Vote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}