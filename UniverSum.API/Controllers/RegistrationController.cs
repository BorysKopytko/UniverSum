using Microsoft.AspNetCore.Mvc;
using UniverSum.API.Models.Enums;

namespace UniverSum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("faculties")]
        public ActionResult<IEnumerable<string>> GetFaculties()
        {
            return Ok(_context.Faculties.Select(x => x.Title).ToList());
        }

        [HttpGet("educationlevels")]
        public ActionResult<IEnumerable<string>> GetEducationLevels(string faculty)
        {
            return Ok(_context.EducationLevels.Where(x => x.Faculty.Title == faculty).Select(x => x.Type).ToList());
        }

        [HttpGet("specialities")]
        public ActionResult<IEnumerable<string>> GetSpecialities(string faculty, string educationLevel)
        {
            return Ok(_context.Specialities
                .Where(x => x.EducationLevel.Faculty.Title == faculty && x.EducationLevel.Type == (EducationLevelType)Convert.ToInt32(educationLevel))
                .Select(x => x.Title).ToList());
        }

        [HttpGet("specialitycourses")]
        public ActionResult<IEnumerable<string>> GetSpecialityCourses(string faculty, string educationLevel, string speciality)
        {
            return Ok(_context.SpecialityCourses
                .Where(x => x.Speciality.EducationLevel.Faculty.Title == faculty
                && x.Speciality.EducationLevel.Type == (EducationLevelType)Convert.ToInt32(educationLevel)
                && x.Speciality.Title == speciality)
                .Select(x => x.Title).ToList());
        }

        [HttpGet("streams")]
        public ActionResult<IEnumerable<string>> GetStreams(string faculty, string educationLevel, string speciality, string specialityCourse)
        {
            return Ok(_context.Streams
                .Where(x => x.SpecialityCourse.Speciality.EducationLevel.Faculty.Title == faculty
                && x.SpecialityCourse.Speciality.EducationLevel.Type == (EducationLevelType)Convert.ToInt32(educationLevel)
                && x.SpecialityCourse.Speciality.Title == speciality
                && x.SpecialityCourse.Title == specialityCourse)
                .Select(x => x.Title).ToList());
        }

        [HttpGet("groups")]
        public ActionResult<IEnumerable<string>> GetGroups(string faculty, string educationLevel, string speciality, 
            string specialityCourse, string stream)
        {
            return Ok(_context.Groups
                .Where(x => x.Stream.SpecialityCourse.Speciality.EducationLevel.Faculty.Title == faculty
                && x.Stream.SpecialityCourse.Speciality.EducationLevel.Type == (EducationLevelType)Convert.ToInt32(educationLevel)
                && x.Stream.SpecialityCourse.Speciality.Title == speciality
                && x.Stream.SpecialityCourse.Title == specialityCourse
                && x.Stream.Title == stream)
                .Select(x => x.Title).ToList());
        }
    }
}
