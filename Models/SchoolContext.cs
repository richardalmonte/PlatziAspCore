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
    }
}