using System;

namespace PlatziAspCore.Models
{
    public class Evaluation : BaseSchoolObject
    {
        #region Properties

        public string StudentId { get; set; }

        public Student Student { get; set; }

        public string SubjectId { get; set; }

        public Subject Subject { get; set; }

        public float Grade { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Grade}, {Student.Name}, {Subject.Name}";
        }

        #endregion
    }
}