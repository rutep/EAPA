using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
namespace webApi.Pages
{
    public class BoardModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly webApi.Data.ApplicationDbContext _context;
        
        public List<MyUser> boardUsers{get;set;}
        public BoardMemberEntity.Data.BoardMember boardMember {get;set;}
        public BoardModel(UserManager<MyUser> userManager, webApi.Data.ApplicationDbContext 
        context)
        {
            _userManager = userManager;
            _context = context;

        }

        // public BoardMemberEntity.Data.BoardMember BoardMember { get;set; }
        public async Task<IActionResult> OnGetAsync()
        {

            // Create the boardmembers
            boardUsers = _userManager.Users.ToList();
            boardMember = await _context.BoardMember.FirstOrDefaultAsync(m => m.Id == 3);
            


            // Find the Boardmembers




            return Page();
        }
    }
}