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
    public class IndexModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.OgloszenieContext _context;

        public IndexModel(Schronisko.Areas.Identity.Data.OgloszenieContext context)
        {
            _context = context;
        }

        public IList<Harmonogram> Harmonogram { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Harmonogram != null)
            {
                Harmonogram = await _context.Harmonogram.ToListAsync();
            }
        }
    }
}
