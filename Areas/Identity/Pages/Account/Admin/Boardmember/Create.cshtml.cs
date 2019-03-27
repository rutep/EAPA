using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoardMemberEntity.Data;
using Microsoft.AspNetCore.Hosting;
using webApi.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace webApi.Pages.Boardmember
{
    public class CreateModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public CreateModel(webApi.Data.ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BoardMember BoardMember { get; set; }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                // Það vantar skjal frá Visual Studio, Pétur ætlaði að búa það til. Annars biðja Helga
                Random random = new System.Random();
                int id = random.Next(0, 100000);
                IFormFile file = HttpContext.Request.Form.Files[0];
                var fileName = Path.Combine(he.WebRootPath + "/images/boardmembers", id  + file.FileName);
                BoardMember.Image = id + file.FileName;

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            } else
            {
                BoardMember.Image = "";
            }

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