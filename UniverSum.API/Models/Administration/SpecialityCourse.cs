using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public class SpecialityCourse : EntityWithTitle
    {
        public List<Stream> Streams { get; set; }
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public Speciality Speciality { get; set; }
    }
}
