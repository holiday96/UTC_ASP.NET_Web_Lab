using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTC_ASP.NET_Web_Lab.Data;
using UTC_ASP.NET_Web_Lab.Models;

namespace UTC_ASP.NET_Web_Lab.Controllers
{
    public class CourseController(SchoolContext db) : Controller
    {
        public IActionResult Index()
        {
            var learners = db.Courses.ToList();
            return View(learners);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title, Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || db.Courses == null)
            {
                return NotFound();
            }

            var course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId, Title, Credits")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(course);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        private bool CourseExists(int id)
        {
            return (db.Courses?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || db.Courses == null)
            {
                return NotFound();
            }

            var course = db.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Courses == null)
            {
                return Problem("Entity set'Courses' is null");
            }
            var course = db.Courses.Find(id);
            if (course != null)
            {
                db.Courses.Remove(course);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
