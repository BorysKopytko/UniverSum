using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Administration;
using UniverSum.API.Models.Courses;

namespace UniverSum.API.Models.Conversations
{
    public  class Conversation : EntityWithTitle
    {
        public List<Profile> Members { get; set; }
        public List<Message> Messages { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        [Required]
        public bool IsUniversity { get; set; }
    }
}
