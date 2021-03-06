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
    public class IndexModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public IndexModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
        {
            _context = context;
        }

        public IList<Zaginiecia> Zaginiecia { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Zaginiecia != null)
            {
                Zaginiecia = await _context.Zaginiecia.ToListAsync();
            }
        }
    }
}
