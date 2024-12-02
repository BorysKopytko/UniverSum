using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public class Speciality : EntityWithTitle
    {
        public List<SpecialityCourse> SpecialityCourses { get; set; }
        [Required]
        public int EducationLevelId { get; set; }
        [Required]
        public EducationLevel EducationLevel { get; set; }
    }
}
