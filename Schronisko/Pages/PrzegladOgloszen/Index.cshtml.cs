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
        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;

        public IndexModel(Schronisko.Areas.Identity.Data.SchroniskoContext context)
        {
            _context = context;
        }

        public IList<Ogloszenie> Ogloszenie { get;set; } = default!;
        
        public async Task OnGetAsync(string Opcja,string searchString)
        {
            var ogloszenia = from m in _context.Ogloszenie select m;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                if (Opcja == "Rasa")
                {
                    ogloszenia = ogloszenia.Where(s => s.Rasa.Contains(searchString));
                }
                else
                {
                    
                    ogloszenia = ogloszenia.Where(s => s.Wiek.ToString().Contains(searchString));
                }   
                
                ogloszenia = ogloszenia.OrderByDescending(s => s.Id);
            }
          Ogloszenie=await ogloszenia.ToListAsync();
        }
    }
}
