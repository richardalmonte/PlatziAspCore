using System.ComponentModel.DataAnnotations;

namespace PlatziAspCore.Models
{
    public enum SchoolType
    {
        [Display(Name = "Pre-Scholar")]
        PreScholar,
        Basic,
        Middle,
        High
    }
}