using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Course
    {
        public Course() {
            Enrollments = [];
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Display(Name = "Tên lớp học")]
        [Required(ErrorMessage = "Tên lớp học là bắt buộc")]
        public string Title { get; set; }

        [Display(Name = "Số tín chỉ")]
        [Required(ErrorMessage = "Số tín chỉ là bắt buộc")]
        [Range(1, 100, ErrorMessage = "Số tín chỉ phải nằm trong khoảng từ 1 đến 100")]
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
