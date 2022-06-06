using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;

namespace Schronisko.Pages.PrzegladOgloszen
{

    public class IndexModel : PageModel
    {
        private readonly Schronisko.Areas.Identity.Data.OgloszenieContext _context;

        public IndexModel(Schronisko.Areas.Identity.Data.OgloszenieContext context)
        {
            _context = context;
        }

        public IList<Ogloszenie> Ogloszenie { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var ogloszenia = from m in _context.Ogloszenie select m;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                
                ogloszenia = ogloszenia.Where(s => s.Rasa.Contains(searchString));
                ogloszenia = ogloszenia.OrderByDescending(s => s.Id);
            }
          Ogloszenie=await ogloszenia.ToListAsync();
        }
    }
}
