using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlatziAspCore.Models
{
    [DisplayColumn(displayColumn: nameof(Name))]
    public class School : BaseSchoolObject
    {

        #region Properties

        [Required]
        public override string Name { get; set; }

        [Display(Name = "School Type")]
        [Required(ErrorMessage = "The School Type cannot be empty")]
        [EnumDataType(typeof(SchoolType))]
        public SchoolType SchoolType { get; set; }

        [Display(Name = "Foundation Year", Prompt = "1900")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0000}")]
        public int FoundationYear { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<Course> Courses { get; set; }
        #endregion

        #region Constructors

        public School(string name, int year) => (Name, FoundationYear) = (name, year);

        public School(string name, int foundationYear, SchoolType schoolType, string country = "", string city = "") : base()
        {
            (Name, FoundationYear) = (name, foundationYear);
            Country = country;
            City = city;
        }

        public School()
        {

        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Name: \"{Name}\", Type: {SchoolType} {System.Environment.NewLine} Country: {Country}, City:{City}";
        }

        #endregion

    }
}