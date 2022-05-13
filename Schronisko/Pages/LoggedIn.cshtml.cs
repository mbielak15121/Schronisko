using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Schronisko.Pages
{
    [Authorize(Policy = "MustBeLoggedIn")]
    public class LoggedInModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
