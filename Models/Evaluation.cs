using System;

namespace PlatziAspCore.Models
{
    public class Evaluation : BaseSchoolObject
    {
        #region Properties

        public Student Student { get; set; }
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

    public class Evaluations
    {
        #region Properties

        public string UniqueId { get; private set; }
        public string Name { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Grade { get; set; }

        #endregion

        #region Constructors

        public Evaluations()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        #endregion
    }
}