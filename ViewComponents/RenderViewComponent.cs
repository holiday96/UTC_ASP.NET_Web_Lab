using Microsoft.AspNetCore.Mvc;
using UTC_ASP.NET_Web_Lab.Models;

namespace UTC_ASP.NET_Web_Lab.ViewComponents
{
    public class RenderViewComponent:ViewComponent
    {
        private readonly List<MenuItem> MenuItems = [];

        public RenderViewComponent()
        {
            MenuItems =
            [
                new MenuItem() { Id = 1, Name = "Home", Link = "/" },
                new MenuItem() { Id = 2, Name = "Branches", Link = "/Admin/Branches/List" },
                new MenuItem() { Id = 3, Name = "Learners", Link = "/Admin/Learners/List" },
                new MenuItem() { Id = 4, Name = "Students", Link = "/Admin/Students/List" },
                new MenuItem() { Id = 5, Name = "Subjects", Link = "/Admin/Subjects/List" },
                new MenuItem() { Id = 6, Name = "Courses", Link = "/Admin/Courses/List" }
            ];
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", MenuItems);
        }
    }
}
