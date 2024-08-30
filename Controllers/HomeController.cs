using UTC_ASP.NET_Web_Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace UTC_ASP.NET_Web_Lab.Controllers
{
    public class HomeController() : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
