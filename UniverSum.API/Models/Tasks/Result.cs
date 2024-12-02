using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Tasks
{
    public sealed class Result : Entity
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public CustomTask Task { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public Profile Student { get; set; }
        [Required]
        public short Mark { get; set; }
    }
}
