using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Administration;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Enums;
using UniverSum.API.Models.Schedule;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Models
{
    public  class Profile : Entity
    {
        [Required]
        public string Email { get; set; } = "default@example.com";
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public ProfileRole Role { get; set; }
        public string? IdentityId { get; set; }
        public List<Group> Groups { get; set; }
        public TeacherPosition? Position { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<RecurringLesson> RecurringLessons { get; set; }
        public List<CustomTask> CreatedTasks { get; set; }
        public List<Result> Results { get; set; }
        public List<Course> Courses { get; set; }
        public List<Link> FavoriteLinks { get; set; }
        public List<Conversation> Conversations { get; set; }
    }
}
