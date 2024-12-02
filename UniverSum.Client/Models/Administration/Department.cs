using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public class Department : EntityWithTitle
    {
        public List<Profile> Teachers { get; set; }
        [Required]
        public int FacultyId { get; set; }
        [Required]
        public Faculty Faculty { get; set; }
    }
}
