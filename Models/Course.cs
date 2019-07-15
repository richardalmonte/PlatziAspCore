using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlatziAspCore.Models
{
    public class Course : BaseSchoolObject
    {
        #region Properties

        [Required]
        public override string Name { get; set; }

        [Required]
        public DayType DayType { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public string Address { get; set; }

        public string SchoolId { get; set; }

        public School School { get; set; }
        #endregion
    }
}