using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTC_ASP.NET_Web_Lab.Data;

namespace UTC_ASP.NET_Web_Lab.Controllers
{
    public class LearnerController(SchoolContext context) : Controller
    {
        public IActionResult Index()
        {
            var learners = context.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
    }
}
