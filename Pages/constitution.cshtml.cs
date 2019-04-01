using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace webApi.Pages
{
    [AllowAnonymous]
    public class constitutionModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public constitutionModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BoardMemberEntity.Data.BoardMember> BoardMember { get; set; }

        public async Task OnGetAsync()
        {
            BoardMember = await _context.BoardMember.ToListAsync();
        }
    }
    
}