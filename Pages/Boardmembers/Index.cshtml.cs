using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoardMemberEntity.Data;
using webApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace webApi.Pages.Boardmembers
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public IndexModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BoardMember> BoardMember { get;set; }
        public IQueryable<MyUser> MyUser {get;set;}
        public IList<MyUser> UserList{get;set;}

        public async Task OnGetAsync()
        {
            BoardMember = await _context.BoardMember.ToListAsync();
            
        }
    }
}
