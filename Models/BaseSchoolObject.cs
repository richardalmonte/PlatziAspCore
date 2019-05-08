using System;

namespace PlatziAspCore.Models
{
    public abstract class BaseSchoolObject
    {
        #region Properties

        public string Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructors

        public BaseSchoolObject()
        {
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Name}, {Id}";
        }

        #endregion
    }
}