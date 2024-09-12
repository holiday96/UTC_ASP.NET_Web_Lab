using System.ComponentModel.DataAnnotations.Schema;

namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Major
    {
        public Major() {
            Learners = [];
        }
        public int MajorID { get; set; }
        public string MajorName { get; set; }
        public virtual ICollection<Learner> Learners { get; set; }
    }
}
