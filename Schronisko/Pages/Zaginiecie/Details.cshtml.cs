using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.Zaginiecie
{
    public class DetailsModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public DetailsModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
        {
            _context = context;
        }

      public Zaginiecia Zaginiecia { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zaginiecia == null)
            {
                return NotFound();
            }

            var zaginiecia = await _context.Zaginiecia.FirstOrDefaultAsync(m => m.Id == id);
            if (zaginiecia == null)
            {
                return NotFound();
            }
            else 
            {
                Zaginiecia = zaginiecia;
            }
            return Page();
        }
    }
}
