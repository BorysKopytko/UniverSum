using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Schedule;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Models.Conversations
{
    public  class Message : Entity
    {
        [Required]
        public int ConversationId { get; set; }
        [Required]
        public Conversation Conversation { get; set; }
        public int? SenderId { get; set; }
        public Profile? Sender { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime SendingDateTime { get; set; }
        public int? IndividualLessonId { get; set; }
        public IndividualLesson? IndividualLesson { get; set; }
        public int? TaskId { get; set; }
        public CustomTask? Task { get; set; }
    }
}
