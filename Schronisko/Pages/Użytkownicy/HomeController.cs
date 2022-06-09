using Microsoft.AspNetCore.Mvc;
using Schronisko.Migrations;

namespace Schronisko.Pages.Użytkownicy
{
    public class HomeController : Controller
    {
        private SchroniskoUser _application;
        public HomeController(SchroniskoUser application)
        {
            _application = application;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
