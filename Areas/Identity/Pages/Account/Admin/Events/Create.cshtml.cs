using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Events
{
    
    public class CreateModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment he;
        private readonly UserManager<MyUser> _userManager;


        public CreateModel(webApi.Data.ApplicationDbContext context, IHostingEnvironment e, UserManager<MyUser> userManager)
        {
            _context = context;
            he = e;
            _userManager = userManager;
        }



        public async Task<IActionResult> OnGetAsync()
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
                return Page();
            }
        }

        [BindProperty]
        public Event.Data.Event Event { get; set; }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Random random = new System.Random();
                int id = random.Next(0, 100000);
                IFormFile file = HttpContext.Request.Form.Files[0];
                var fileName = Path.Combine(he.WebRootPath + "\\images\\events", id  + file.FileName);
                Event.Image = id + file.FileName;

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