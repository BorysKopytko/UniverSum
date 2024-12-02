using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Models.Schedule
{
    public  class IndividualLesson : Entity
    {
        [Required]
        public DateTime Date { get; set; }
        public int? RecurringLessonId { get; set; }
        public RecurringLesson? RecurringLesson { get; set; }
        public int? ContentId { get; set; }
        public Content? Content { get; set; }
        public int? TaskId { get; set; }
        public CustomTask? Task { get; set; }
        public List<Message> Messages { get; set; }
    }
}
