using System.ComponentModel.DataAnnotations.Schema;

namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Learner
    {
        public Learner() {
            Enrollments = [];
        }
        public int LearnerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
