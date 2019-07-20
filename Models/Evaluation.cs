using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatziAspCore.Models
{
    [DisplayColumn(displayColumn: nameof(Name))]
    public class Evaluation : BaseSchoolObject
    {
        #region Properties

        [Required]
        public override string Name { get; set; }

        //[Required]
        [Display(Name = "Subject")]
        public string SubjectId { get; set; }

        //[Required]
        [Display(Name = "Student")]
        public string StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }

        [Range(0, 5)]
        public float Grade { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Grade}, {Student?.Name}, {Subject?.Name}";
        }

        #endregion
    }
}