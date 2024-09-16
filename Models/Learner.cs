using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Learner
    {
        public Learner() {
            Enrollments = [];
        }
        public int LearnerID { get; set; }

        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Display(Name = "Tên")]
        public string FirstMidName { get; set; }

        [Display(Name = "Ngày nhập học")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Ngành")]
        public int MajorID { get; set; }

        [Display(Name = "Ngành")]
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
