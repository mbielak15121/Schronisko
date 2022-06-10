using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.Ogloszenia
{
    public class DetailsModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public DetailsModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
        {
            _context = context;
        }

      public Ogloszenie Ogloszenie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ogloszenie == null)
            {
                return NotFound();
            }

            var ogloszenie = await _context.Ogloszenie.FirstOrDefaultAsync(m => m.Id == id);
            if (ogloszenie == null)
            {
                return NotFound();
            }
            else 
            {
                Ogloszenie = ogloszenie;
            }
            return Page();
        }
    }
}
