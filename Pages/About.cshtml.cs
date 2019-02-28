using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webApi.Data;
using BoardMemberEntity.Data;
using Microsoft.EntityFrameworkCore;

namespace webApi.Pages
{
    [AllowAnonymous]
    public class AboutModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public object BoardMemberEntity { get; private set; }

        //About Entity
        public string Message { get; set; }
        public string tester {get; set; }
        public List<IdentityUserRole<string>> Roles { get; set; }

        public AboutModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        private static readonly HttpClient client = new HttpClient();

        public async Task OnGetAsync()
        {
            BoardMemberEntity = await _context.BoardMember.ToListAsync();
            //Controller 
            Message = "Your application description page.";
            tester = "teetetetetetet";
        }
    }
}
