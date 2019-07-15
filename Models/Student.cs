using System.Collections.Generic;

namespace PlatziAspCore.Models
{
    public class Student : BaseSchoolObject
    {
        public string CourseId { get; set; }

        public Course Course { get; set; }

        public List<Evaluation> Evaluations { get; set; }

    }
}