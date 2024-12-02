using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniverSum.API.Identity;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Enums;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public CoursesController(ApplicationDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("coursescategory")]
        public ActionResult<IEnumerable<Course>> GetCoursesByCategory(string category)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (category == "all")
                return Ok(_context.Courses.Where(x => x.Members.Contains(profile)).ToList());
            else if (category == "required")
                return Ok(_context.Courses.Where(x => x.Members.Contains(profile) && x.Type == CourseType.Required).ToList());
            else if (category == "faculty")
                return Ok(_context.Courses.Where(x => x.Members.Contains(profile) && x.Type == CourseType.FacultyElective).ToList());
            else if (category == "university")
                return Ok(_context.Courses.Where(x => x.Members.Contains(profile) && x.Type == CourseType.UniversityElective).ToList());
            return Ok();
        }

        [HttpGet("course")]
        public ActionResult<Course> GetCourse(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.Courses.Where(x => x.Members.Contains(profile) && x.Id == id).ToList());
        }
    }
}

