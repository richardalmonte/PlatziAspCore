using System.Collections.Generic;

namespace PlatziAspCore.Models
{
    public class Course : BaseSchoolObject
    {
        #region Properties

        public DayType DayType { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public string Address { get; set; }

        public string SchoolId { get; set; }

        public School School { get; set; }
        #endregion
    }
}