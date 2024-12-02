using UniverSum.API.Models.Abstracts;
using UniverSum.API.Models.Conversations;

namespace UniverSum.API.Models.Administration
{
    public class Faculty : EntityWithTitle
    {
        public List<Department> Departments { get; set; }
        public List<EducationLevel> EducationLevels { get; set; }
        public List<Conversation> Conversations { get; set; }
    }
}
