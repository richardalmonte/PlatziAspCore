using System.Collections.Generic;

namespace PlatziAspCore.Models
{
    public class School : BaseSchoolObject

    {

        #region Properties

        public int FoundationYear { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public SchoolType SchoolType { get; set; }

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