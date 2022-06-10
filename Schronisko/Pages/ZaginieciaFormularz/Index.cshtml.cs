using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.ZaginieciaFormularz
{
    public class CreateModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public CreateModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zaginiecia Zaginiecia { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Zaginiecia == null || Zaginiecia == null)
            {
                return Page();
            }

            _context.Zaginiecia.Add(Zaginiecia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
