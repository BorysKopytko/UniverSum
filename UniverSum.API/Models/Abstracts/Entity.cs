using System.ComponentModel.DataAnnotations;

namespace UniverSum.API.Models.Abstracts
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
