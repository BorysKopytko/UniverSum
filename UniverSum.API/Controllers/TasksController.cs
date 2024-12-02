using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniverSum.API.Identity;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public TasksController(ApplicationDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("tasks")]
        public ActionResult<IEnumerable<CustomTask>> GetTasks()
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var courses = _context.Courses.Where(x => x.Members.Contains(profile)).ToList();
            return Ok(_context.Tasks.Where(x => courses.Contains(x.Course)));
        }

        [HttpGet("task")]
        public ActionResult<CustomTask> GetTask(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var courses = _context.Courses.Where(x => x.Members.Contains(profile)).ToList();
            return Ok(_context.Tasks.Where(x => courses.Contains(x.Course) && x.Id == id));
        }


    }
}

