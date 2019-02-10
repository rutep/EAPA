using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webApi.Pages
{
    public class AboutModel : PageModel
    {
        //About Entity
        public string Message { get; set; }
        public string tester {get; set; }

       
        private static readonly HttpClient client = new HttpClient();

        public async Task OnGetAsync()
        {
            //Controller 
            Message = "Your application description page.";
            tester = "teetetetetetet";
        }
    }
}
