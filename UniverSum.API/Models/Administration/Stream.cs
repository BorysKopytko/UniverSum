using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public class Stream : EntityWithTitle
    {
        public List<Group> Groups { get; set; }
        [Required]
        public int SpecialityCourseId { get; set; }
        [Required]
        public SpecialityCourse SpecialityCourse { get; set; }
    }
}
