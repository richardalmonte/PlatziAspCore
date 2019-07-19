using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlatziAspCore.Models
{
    [DisplayColumn(displayColumn: nameof(Name))]
    public class Student : BaseSchoolObject
    {
        [Required]
        public override string Name { get; set; }

        [Required]
        [Display(Name = "Course")]
        public string CourseId { get; set; }

        public Course Course { get; set; }

        public List<Evaluation> Evaluations { get; set; }

    }
}