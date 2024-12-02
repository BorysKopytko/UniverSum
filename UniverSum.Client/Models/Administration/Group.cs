using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public class Group : EntityWithTitle
    {
        public List<Profile> Students { get; set; }
        public int? StreamId { get; set; }
        public Stream? Stream { get; set; }
    }
}
