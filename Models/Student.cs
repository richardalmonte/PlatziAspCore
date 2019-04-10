using System.Collections.Generic;

namespace PlatziAspCore.Models
{
    public class Student : BaseSchoolObject
    {
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}