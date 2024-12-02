using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Enums;

namespace UniverSum.API.Models.Administration
{
    public class EducationLevel : Entity
    {
        [Required]
        public EducationLevelType Type { get; set; }
        public List<Speciality> Specialities { get; set; }
        [Required]
        public int FacultyId { get; set; }
        [Required]
        public Faculty Faculty { get; set; }
    }
}
