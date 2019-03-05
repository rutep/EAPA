using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace webApi.Pages.Grants
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
        public Grant.Data.Grant Grant { get; set; }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Random random = new System.Random();
                int id = random.Next(0, 100000);
                IFormFile file = HttpContext.Request.Form.Files[0];
                var fileName = Path.Combine(he.WebRootPath + "\\images\\grants", id + file.FileName);
                Grant.Image = id + file.FileName;

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            else
            {
                Grant.Image = "";
            }



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grant.Add(Grant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}