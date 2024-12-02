using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniverSum.API.Identity;
using UniverSum.API.Models.Schedule;

namespace UniverSum.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;
        
        public ScheduleController(ApplicationDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("schedule")]
        public ActionResult<IndividualLesson> GetIndividualLesson(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.IndividualLessons.Where(x => x.Id == id
            && x.RecurringLesson.Members.Contains(profile)).FirstOrDefault());
        }

        [HttpGet("scheduletoday")]
        public ActionResult<IEnumerable<IndividualLesson>> GetIndividualLessonsForToday()
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.IndividualLessons.Where(x=>x.Date == DateTime.Today 
            && x.RecurringLesson.Members.Contains(profile)).ToList());
        }

        [HttpGet("scheduletomorrow")]
        public ActionResult<IEnumerable<IndividualLesson>> GetIndividualLessonForTomorrow()
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.IndividualLessons.Where(x => x.Date == DateTime.Today.AddDays(1)
            && x.RecurringLesson.Members.Contains(profile)).ToList());
        }

        [HttpGet("schedulethisweek")]
        public ActionResult<IEnumerable<IndividualLesson>> GetIndividualLessonsForThisWeek()
        {
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - startOfWeek)) % 7;
            DateTime weekStart = today.AddDays(-diff);
            DateTime weekEnd = weekStart.AddDays(6);

            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.IndividualLessons.Where(x => x.Date >= weekStart && x.Date <= weekEnd
            && x.RecurringLesson.Members.Contains(profile)).ToList());
        }

        [HttpGet("schedulenextweek")]
        public ActionResult<IEnumerable<IndividualLesson>> GetIndividualLessonsForNextWeek()
        {
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - startOfWeek)) % 7;
            DateTime weekStart = today.AddDays(-diff);
            DateTime weekEnd = weekStart.AddDays(6);
            DateTime nextWeekStart = weekStart.AddDays(7);
            DateTime nextWeekEnd = weekEnd.AddDays(7);

            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.IndividualLessons.Where(x => x.Date >= nextWeekStart && x.Date <= nextWeekEnd
            && x.RecurringLesson.Members.Contains(profile)).ToList());
        }
    }
}
