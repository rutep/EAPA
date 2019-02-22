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

namespace webApi.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment he;
        public DeleteModel(webApi.Data.ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        [BindProperty]
        public Event.Data.Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FindAsync(id);

            if (Event != null)
            {
                var fileName = Path.Combine(he.WebRootPath + "\\images\\events", Event.Image);
                System.IO.File.Delete(fileName);

                _context.Event.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        

    }
}
