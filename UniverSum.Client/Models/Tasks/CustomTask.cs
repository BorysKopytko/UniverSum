using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Enums;
using TaskStatus = UniverSum.API.Models.Enums.TaskStatus;

namespace UniverSum.API.Models.Tasks
{
    public sealed class CustomTask : EntityWithTitle
    {
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime? EndDateTime { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        [Required]
        public TaskPriority Priority { get; set; }
        public List<Message> Messages { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public Profile Creator { get; set; }
        public short? MaxMark { get; set; }
        public List<Result> Results { get; set; }
    }
}
