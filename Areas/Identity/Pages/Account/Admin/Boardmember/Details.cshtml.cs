﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Event.Data;
using webApi.Data;
using Microsoft.AspNetCore.Identity;

namespace webApi.Pages.Boardmember
{
    public class DetailsModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public DetailsModel(webApi.Data.ApplicationDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public BoardMemberEntity.Data.BoardMember BoardMember { get; set; }


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

                BoardMember = await _context.BoardMember.FirstOrDefaultAsync(m => m.Id == id);


                if (BoardMember == null)
                {
                    return NotFound();
                }
                return Page();

            }
        }
    }
}
