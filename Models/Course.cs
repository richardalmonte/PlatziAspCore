using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlatziAspCore.Models
{
    public class Course : BaseSchoolObject
    {
        #region Properties

        [Required(ErrorMessage = "The name is required! Please, provide a valid name")]
        public override string Name { get; set; }

        [Required]
        [Display(Name = "Day Type", ShortName = "Type")]
        [EnumDataType(typeof(DayType))]
        public DayType DayType { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }


        public string Address { get; set; }

        [Display(Name = "School", Prompt = "Provide a Name")]
        public string SchoolId { get; set; }

        public School School { get; set; }
        #endregion
    }
}