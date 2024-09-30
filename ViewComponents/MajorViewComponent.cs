using Microsoft.AspNetCore.Mvc;
using UTC_ASP.NET_Web_Lab.Data;
using UTC_ASP.NET_Web_Lab.Models;

namespace UTC_ASP.NET_Web_Lab.ViewComponents
{
    public class MajorViewComponent(SchoolContext db) : ViewComponent
    {
        private readonly List<Major> majors = [.. db.Majors];

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor", majors);
        }
    }
}
