using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.ZaginieciaAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.OgloszenieContext _context;

        public DeleteModel(Schronisko.Areas.Identity.Data.OgloszenieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zaginiecia == null)
            {
                return NotFound();
            }
            var zaginiecia = await _context.Zaginiecia.FindAsync(id);

            if (zaginiecia != null)
            {
                Zaginiecia = zaginiecia;
                _context.Zaginiecia.Remove(Zaginiecia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
