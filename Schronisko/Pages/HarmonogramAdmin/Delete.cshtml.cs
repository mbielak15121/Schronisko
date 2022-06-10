using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.HarmonogramAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.OgloszenieContext _context;

        public DeleteModel(Schronisko.Areas.Identity.Data.OgloszenieContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Harmonogram Harmonogram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Harmonogram == null)
            {
                return NotFound();
            }

            var harmonogram = await _context.Harmonogram.FirstOrDefaultAsync(m => m.Id == id);

            if (harmonogram == null)
            {
                return NotFound();
            }
            else 
            {
                Harmonogram = harmonogram;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Harmonogram == null)
            {
                return NotFound();
            }
            var harmonogram = await _context.Harmonogram.FindAsync(id);

            if (harmonogram != null)
            {
                Harmonogram = harmonogram;
                _context.Harmonogram.Remove(Harmonogram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
