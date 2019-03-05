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

        public IList<MyUser> boardUsers{get;set;}

        public BoardModel(UserManager<MyUser> userManager, webApi.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<BoardMemberEntity.Data.BoardMember> BoardMember { get;set; }
        public async Task<IActionResult> OnGetAsync()
        {
            // Find the Boardmembers


            BoardMember = await _context.BoardMember.ToListAsync();
        
            boardUsers = await _userManager.GetUsersInRoleAsync("BoardMember");


            return Page();
        }
    }
}