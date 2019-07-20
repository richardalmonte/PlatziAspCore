using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        #endregion
    }
}