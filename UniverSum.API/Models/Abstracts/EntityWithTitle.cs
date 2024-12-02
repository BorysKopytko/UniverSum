using System.ComponentModel.DataAnnotations;

namespace UniverSum.API.Models.Abstracts
{
    public abstract class EntityWithTitle : Entity
    {
        public string? Title { get; set; }
    }
}
