using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webApi.Pages
{
    [AllowAnonymous]
    public class AboutModel : PageModel
    {
        //About Entity
        public string Message { get; set; }
        public string tester {get; set; }
        public List<IdentityUserRole<string>> Roles { get; set; }


        private static readonly HttpClient client = new HttpClient();

        public async Task OnGetAsync()
        {
        
            //Controller 
            Message = "Your application description page.";
            tester = "teetetetetetet";
        }
    }
}
