using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Administration;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Enums;

namespace UniverSum.API.Models
{
    public  class Link : EntityWithTitle
    {
        [Required]
        public Uri Url { get; set; }
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public bool IsUniversity { get; set; }
        public List<Profile> FavoriteProfiles { get; set; }
        public Uri? LogoPath { get; set; }
        public int? ContentId { get; set; }
        public Content? Content { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public LinkFileType? FileType { get; set; }
    }
}
