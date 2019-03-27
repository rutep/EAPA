﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FAQ.Data;
using webApi.Data;

namespace webApi.Areas.Identity.Pages.Account.Admin.FAQS
{
    public class DetailsModel : PageModel
    {
        private readonly webApi.Data.ApplicationDbContext _context;

        public DetailsModel(webApi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public FAQ.Data.FAQ FAQ { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FAQ = await _context.Faq.FirstOrDefaultAsync(m => m.Id == id);

            if (FAQ == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
