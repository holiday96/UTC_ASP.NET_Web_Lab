using System.ComponentModel.DataAnnotations.Schema;

namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Course
    {
        public Course() {
            Enrollments = [];
        }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
