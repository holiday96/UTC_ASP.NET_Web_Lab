using Microsoft.EntityFrameworkCore;
using UTC_ASP.NET_Web_Lab.Models;

namespace UTC_ASP.NET_Web_Lab.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()
            );
            context.Database.EnsureCreated();
            if (context.Majors.Any())
            {
                return;
            }

            // Init Major data
            var majors = new Major[]
            {
                    new() { MajorName = "IT" },
                    new() { MajorName = "Economics" },
                    new() { MajorName = "Mathematics" },
            };
            foreach (Major major in majors)
            {
                context.Majors.Add(major);
            }
            context.SaveChanges();

            // Init Learner data
            var learners = new Learner[]
            {
                    new() { FirstMidName = "Carson", LastName = "AlexanderJ", EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                    new() { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 },
            };
            foreach (Learner learner in learners)
            {
                context.Learners.Add(learner);
            }
            context.SaveChanges();

            // Init Course data
            var courses = new Course[]
            {
                    new() { CourseId = 1050, Title = "Chemistry", Credits = 3 },
                    new() { CourseId = 4022, Title = "Microeconomics", Credits = 3 },
                    new() { CourseId = 4041, Title = "Macroeconomics", Credits = 3 },
            };
            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();

            // Init Enrollment data
            var enrollments = new Enrollment[] {
                    new() { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new() { LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                    new() { LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                    new() { LearnerID = 2, CourseID = 4041, Grade = 7f },
                };
            foreach (Enrollment enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }
            context.SaveChanges();
        }
    }
}
