using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatziAspCore.Models
{
    [DisplayColumn(displayColumn: nameof(Name))]
    public class Course : BaseSchoolObject
    {
        #region Properties

        [Required(ErrorMessage = "The name is required! Please, provide a valid name")]
        public override string Name { get; set; }

        [Required]
        [Display(Name = "Day Type", ShortName = "Type")]
        [EnumDataType(typeof(DayType))]
        public DayType DayType { get; set; }

        public string Address { get; set; }

        [Display(Name = "School", Prompt = "Provide a Name")]
        public string SchoolId { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public School School { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }
        #endregion
    }
}