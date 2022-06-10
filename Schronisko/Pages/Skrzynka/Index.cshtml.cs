using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Models;


namespace Schronisko.Pages.Skrzynka
{
    
    public class IndexModel : PageModel
    {

        private readonly UserManager<SchroniskoUsers> _userManager;
        private readonly SignInManager<SchroniskoUsers> _signInManager;

        private readonly Schronisko.Areas.Identity.Data.SchroniskoContext _context;
       
        
       
        public IndexModel(Schronisko.Areas.Identity.Data.SchroniskoContext context, UserManager<SchroniskoUsers> userManager,
        SignInManager<SchroniskoUsers> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
       
        public IList<Wiadomosci> Wiadomosci { get;set; } = default!;
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userEmail = user.Email;

            
            Wiadomosci = _context.Wiadomosci.Where(p => p.Odbiorca == userEmail).ToList();
            
        }

        
    }

}
