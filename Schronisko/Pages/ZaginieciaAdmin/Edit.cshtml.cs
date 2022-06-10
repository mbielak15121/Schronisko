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

namespace Schronisko.Pages.ZaginieciaAdmin
{
    public class EditModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public EditModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
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

            var zaginiecia =  await _context.Zaginiecia.FirstOrDefaultAsync(m => m.Id == id);
            if (zaginiecia == null)
            {
                return NotFound();
            }
            Zaginiecia = zaginiecia;
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

            _context.Attach(Zaginiecia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaginieciaExists(Zaginiecia.Id))
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

        private bool ZaginieciaExists(int id)
        {
          return (_context.Zaginiecia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
