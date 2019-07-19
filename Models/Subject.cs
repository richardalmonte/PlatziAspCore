using System.ComponentModel.DataAnnotations;

namespace PlatziAspCore.Models
{
    [DisplayColumn(displayColumn: nameof(Name))]
    public class Subject : BaseSchoolObject
    {
        #region Properties

        [Required]
        public override string Name { get; set; }

        [Required]
        [Display(Name = "Course")]
        public string CourseId { get; set; }

        public Course Course { get; set; }

        #endregion
    }
}