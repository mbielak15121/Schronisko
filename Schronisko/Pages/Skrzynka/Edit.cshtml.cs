using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.Skrzynka
{
    public class EditModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public EditModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
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

            var wiadomosci =  await _context.Wiadomosci.FirstOrDefaultAsync(m => m.Id == id);
            if (wiadomosci == null)
            {
                return NotFound();
            }
            Wiadomosci = wiadomosci;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wiadomosci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WiadomosciExists(Wiadomosci.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WiadomosciExists(int id)
        {
          return (_context.Wiadomosci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
