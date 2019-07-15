namespace PlatziAspCore.Models
{
    public class Subject : BaseSchoolObject
    {
        #region Properties

        public string CourseId { get; set; }

        public Course Course { get; set; }
        
        #endregion
    }
}