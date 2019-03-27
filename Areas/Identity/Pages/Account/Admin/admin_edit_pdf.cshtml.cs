using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webApi.Data;

namespace webApi.Areas.Identity.Pages.Account.Admin
{
    public class admin_edit_pdfModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly IHostingEnvironment he;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<MyUser> manager;
        //Here I will create the variables that goes in to the model
        public List<MyUser> user { get; set; }
        public admin_edit_pdfModel(UserManager<MyUser> userManager, IHostingEnvironment e)
        {
            _userManager = userManager;
            he = e;
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
        [HttpPost("UploadByLaws")]
        public IActionResult OnPost()
        {
            
            if (HttpContext.Request.Form.Files.Count <= 2)
            {
                var fileName = "";
                foreach (IFormFile file in HttpContext.Request.Form.Files)
                {
                    if (file.ContentType != "application/pdf")
                {
                    ModelState.AddModelError(string.Empty, "File Extension Is Invalid - Only Upload PDF File");
                    return Page();
                }
                if(file.Name == "files-law"){
                    fileName = Path.Combine(he.WebRootPath + "/assets/", "EABA-By-Laws.pdf");
                }
                if(file.Name == "files-info"){
                    fileName = Path.Combine(he.WebRootPath + "/assets/", "EABA-Member-Info.pdf");
                }
                

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                }
                //IFormFile file = HttpContext.Request.Form.Files[0];
                
            }
             return Page();
        }
    }
}