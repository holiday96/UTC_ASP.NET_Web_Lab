using UTC_ASP.NET_Web_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UTC_ASP.NET_Web_Lab.Controllers
{
    public class StudentController : Controller
    {
        private readonly List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            listStudents =
            [
                new() {
                    Id = 101, Name = "Hải Nam", Branch = Branch.IT, Gender = Gender.Male,
                    DateOfBirth = DateTime.ParseExact("01/02/1999", "dd/MM/yyyy", null), IsRegular = true, Address = "A1-2018", Email = "nam@g.com"
                },
                new() {
                    Id = 102, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.Female,
                    DateOfBirth = DateTime.ParseExact("01/02/1999", "dd/MM/yyyy", null), IsRegular = true, Address = "A1-2019", Email = "tu@g.com"
                },
                new() {
                    Id = 103, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male,
                    DateOfBirth = DateTime.ParseExact("01/02/1999", "dd/MM/yyyy", null), IsRegular = false, Address = "A1-2020", Email = "phong@g.com"
                },
                new() {
                    Id = 104, Name = "Xuân Mai", Branch = Branch.EE, Gender = Gender.Female,
                    DateOfBirth = DateTime.ParseExact("01/02/1999", "dd/MM/yyyy", null), IsRegular = false, Address = "A1-2021", Email = "mai@g.com"
                }
            ];
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new() { Text = "IT", Value = "1" },
                new() { Text = "BE", Value = "2" },
                new() { Text = "CE", Value = "3" },
                new() { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Check image input
                if (student.ProfileImage != null && student.ProfileImage.Length > 0)
                {
                    var fileName = Path.GetFileName(student.ProfileImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await student.ProfileImage.CopyToAsync(stream);
                    }
                    student.ProfileImagePath = $"/images/{fileName}";
                }

                // Add student
                student.Id = listStudents.Last().Id + 1;
                listStudents.Add(student);

                return View("Index", listStudents);
            };

            // Load data
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new() { Text = "IT", Value = "1" },
                new() { Text = "BE", Value = "2" },
                new() { Text = "CE", Value = "3" },
                new() { Text = "EE", Value = "4" }
            };

            return View();
        }
    }
}
