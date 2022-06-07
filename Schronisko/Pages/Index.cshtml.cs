using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Migrations.Ogloszenie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schronisko.Areas.Identity.Data;

namespace Schronisko.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Schronisko.Areas.Identity.Data.OgloszenieContext _context;
        public IndexModel(Schronisko.Areas.Identity.Data.OgloszenieContext context)
        {
            _context = context;
        }
        public IList<Zaginiecia> Zaginiecia { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
       
        public async Task OnGetAsync()
        {
            
            var zaginiecie = from m in _context.Zaginiecia select m;
            if (_context.Zaginiecia != null)
            {
                
             zaginiecie = zaginiecie.Where(s => s.Aktualne==true && s.Zaakceptowane == true);
             Zaginiecia = await ogloszenia.ToListAsync();
           
            }
        }
    }
}