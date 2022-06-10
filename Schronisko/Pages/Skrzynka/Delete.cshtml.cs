using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.Skrzynka
{
    public class DeleteModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public DeleteModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Wiadomosci Wiadomosci { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wiadomosci == null)
            {
                return NotFound();
            }

            var wiadomosci = await _context.Wiadomosci.FirstOrDefaultAsync(m => m.Id == id);

            if (wiadomosci == null)
            {
                return NotFound();
            }
            else 
            {
                Wiadomosci = wiadomosci;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Wiadomosci == null)
            {
                return NotFound();
            }
            var wiadomosci = await _context.Wiadomosci.FindAsync(id);

            if (wiadomosci != null)
            {
                Wiadomosci = wiadomosci;
                _context.Wiadomosci.Remove(Wiadomosci);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
