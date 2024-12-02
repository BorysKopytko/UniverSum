using UniverSum.API.Models.Abstracts;

namespace UniverSum.API.Models.Administration
{
    public  class Place : EntityWithTitle
    {
        public List<Classroom> Classrooms { get; set; }
    }
}
