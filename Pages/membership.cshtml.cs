﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webApi.Pages
{
    [AllowAnonymous]
    public class membershipModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}