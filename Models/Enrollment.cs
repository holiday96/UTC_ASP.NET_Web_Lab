﻿namespace UTC_ASP.NET_Web_Lab.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int LearnerID { get; set; }
        public float Grade { get; set; }
        public virtual Learner? Learner { get; set; }
        public virtual Course? Course { get; set; }
    }
}
