using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace webApi.Pages.Events
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
        public Event.Data.Event Event { get; set; }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                var fileName = Path.Combine(he.WebRootPath + "\\images\\events", file.FileName);
                Event.Image = file.FileName;
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            } else
            {
                Event.Image = "";
            }

            
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Event.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}