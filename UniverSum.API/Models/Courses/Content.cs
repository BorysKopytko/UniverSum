using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Courses
{
    public  class Content : EntityWithTitle
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public Course Course { get; set; }
        public List<Link> Links { get; set; }
    }
}
