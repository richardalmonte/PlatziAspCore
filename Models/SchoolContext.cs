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
            modelBuilder.Entity<School>().HasData(school);

            modelBuilder.Entity<Subject>().HasData(
                 new Subject
                 {
                     Name = "Programming",
                     Id = Guid.NewGuid().ToString()
                 },
                new Subject
                {
                    Name = "Mathematics",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject
                {
                    Name = "Physics",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject
                {
                    Name = "English",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject
                {
                    Name = "History",
                    Id = Guid.NewGuid().ToString()
                }
            );

            modelBuilder.Entity<Student>().HasData(GenerateRStudents().ToArray());
        }

        private List<Student> GenerateRStudents()
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] surName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var students = from n1 in name1
                           from n2 in name2
                           from a1 in surName1
                           select new Student { Name = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return students.OrderBy((x) => x.Id).ToList();
        }
    }
}