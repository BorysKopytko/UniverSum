using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Administration;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Enums;

namespace UniverSum.API.Models.Schedule
{
    public class RecurringLesson: Entity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public WeekMode WeekMode { get; set; }
        [Required]
        public WeekDay WeekDay { get; set; }
        public LessonType LessonType { get; set; }
        [Required]
        public int LessonTimeSpanId { get; set; }
        [Required]
        public LessonTimeSpan TimeSpan { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public Course Course { get; set; }
        public List<Profile> Members { get; set; }
        [Required]
        public int ClassroomId { get; set; }
        [Required]
        public Classroom Classroom { get; set; }
        public List<IndividualLesson> IndividualLessons { get; set; }
    }
}
