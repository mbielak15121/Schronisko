using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.Ogloszenia
{
    public class CreateModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.OgloszenieContext _context;

        public CreateModel(Schronisko.Areas.Identity.Data.OgloszenieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ogloszenie Ogloszenie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Ogloszenie == null || Ogloszenie == null)
            {
                return Page();
            }

            _context.Ogloszenie.Add(Ogloszenie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
