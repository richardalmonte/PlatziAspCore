using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlatziAspCore.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        #region Constructors

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var school = new School
            {
                FoundationYear = 2005,
                Id = Guid.NewGuid().ToString(),
                Name = "Platzi School",
                City = "Bogotá",
                Country = "Colombia",
                SchoolType = SchoolType.High,
                Address = "Av. Siempre Viva"
            };

            var courses = LoadCourses(school);

            var subjects = LoadSubjects(courses);

            var students = LoadStudents(courses);

            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Course>().HasData(courses.ToArray());
            modelBuilder.Entity<Subject>().HasData(subjects.ToArray());
            modelBuilder.Entity<Student>().HasData(students.ToArray());
        }

        private static List<Subject> LoadSubjects(List<Course> courses)
        {
            var subjects = new List<Subject>();

            foreach (var course in courses)
            {
                var subjectList = new List<Subject>()
                {
                    new Subject
                    {
                        Name = "Programming",
                        Id = Guid.NewGuid().ToString(),
                        CourseId = course.Id
                    },
                    new Subject
                    {
                        Name = "Mathematics",
                        Id = Guid.NewGuid().ToString(),
                        CourseId = course.Id
                    },
                    new Subject
                    {
                        Name = "Physics",
                        Id = Guid.NewGuid().ToString(),
                        CourseId = course.Id
                    },
                    new Subject
                    {
                        Name = "English",
                        Id = Guid.NewGuid().ToString(),
                        CourseId = course.Id
                    },
                    new Subject
                    {
                        Name = "History",
                        Id = Guid.NewGuid().ToString(),
                        CourseId = course.Id
                    }
                };

                subjects.AddRange(subjectList);
                //course.Subjects = subjectList;
            }

            return subjects;
        }

        private static List<Course> LoadCourses(School school)
        {
            return new List<Course>()
            {
                new Course()
                {
                    Id =  Guid.NewGuid().ToString(),
                    SchoolId =  school.Id,
                    Name = "101",
                    DayType = DayType.Morning
                },
                new Course()
                {
                    Id =  Guid.NewGuid().ToString(),
                    SchoolId =  school.Id,
                    Name = "201",
                    DayType = DayType.Afternoon
                },
                new Course()
                {
                    Id =  Guid.NewGuid().ToString(),
                    SchoolId =  school.Id,
                    Name = "301",
                    DayType = DayType.Afternoon
                },
                new Course()
                {
                    Id =  Guid.NewGuid().ToString(),
                    SchoolId =  school.Id,
                    Name = "401",
                    DayType = DayType.Night
                },
                new Course()
                {
                    Id =  Guid.NewGuid().ToString(),
                    SchoolId =  school.Id,
                    Name = "501",
                    DayType = DayType.Morning
                }
            };
        }

        private List<Student> LoadStudents(List<Course> courses)
        {
            var studentList = new List<Student>();

            var random = new Random();
            foreach (var course in courses)
            {
                var randomQty = random.Next(5, 20);
                var randomStudents = GenerateRStudents(course, randomQty);
                studentList.AddRange(randomStudents);
            }

            return studentList;
        }

        private List<Student> GenerateRStudents(Course course, int quantity)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] surName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var students = from n1 in name1
                           from n2 in name2
                           from a1 in surName1
                           select new Student
                           {
                               Name = $"{n1} {n2} {a1}",
                               Id = Guid.NewGuid().ToString(),
                               CourseId = course.Id
                           };

            return students.OrderBy((x) => x.Id).Take(quantity).ToList();
        }
    }
}