using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoardMemberEntity.Data;
using webApi.Data;

namespace webApi.Pages.Boardmembers
{
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
            
            MyUser = from c in _context.BoardMember
                    join u in _context.Users
                    on c.UserId equals u.Id
                    select u;
            UserList = MyUser.ToList();
            
        }
    }
}
