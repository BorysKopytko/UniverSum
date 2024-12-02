using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Enums;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Models.Courses
{
    public  class Course : EntityWithTitle
    {
        [Required]
        public CourseType Type { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Profile> Members { get; set; }
        public List<Content> Contents { get; set; }
        public List<CustomTask> Tasks { get; set; }
        public List<Link> Links { get; set; }
        public int? ConversationId { get; set; }
        public Conversation? Conversation { get; set; }
    }
}
