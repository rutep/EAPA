﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grant.Data;
using webApi.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Grants
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly IHostingEnvironment he;

        public DeleteModel(webApi.Data.ApplicationDbContext context, IHostingEnvironment e, UserManager<MyUser> userManager)
        {
            _context = context;
            he = e;
            _userManager = userManager;
        }

        [BindProperty]
        public Grant.Data.Grant Grant { get; set; }

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

                Grant = await _context.Grant.FirstOrDefaultAsync(m => m.Id == id);

                if (Grant == null)
                {
                    return NotFound();
                }
                return Page();

            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grant = await _context.Grant.FindAsync(id);

            if (Grant.Image != "")
            {
                var fileName = Path.Combine(he.WebRootPath + "\\images\\grants", Grant.Image);
                System.IO.File.Delete(fileName);
            }

            if (Grant != null)
            {
                _context.Grant.Remove(Grant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }



    }
}
