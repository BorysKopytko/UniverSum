using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public  class Classroom : EntityWithTitle
    {
        [Required]
        public int PlaceId { get; set; }
        [Required]
        public Place Place { get; set; }
    }
}
