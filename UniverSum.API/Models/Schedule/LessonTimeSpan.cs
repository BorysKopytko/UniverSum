using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Schedule
{
    public class LessonTimeSpan : Entity
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public short? LessonNumber { get; set; }
        public List<RecurringLesson> RecurringLessons { get; set; }
    }
}
