using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Event.Data;
using webApi.Data;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Microsoft.AspNetCore.Http.Internal;
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
            IFormFile file = HttpContext.Request.Form.Files[0];

            var fileName = Path.Combine(he.WebRootPath + "\\images\\events", file.FileName);
            file.CopyTo(new FileStream(fileName, FileMode.Create));
            Event.Image = file.FileName;


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