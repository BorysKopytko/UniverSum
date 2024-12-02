using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniverSum.API.Identity;
using UniverSum.API.Models;
using UniverSum.API.Models.Enums;
using UniverSum.API.Models.Tasks;

namespace UniverSum.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public LinksController(ApplicationDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("linkscategory")]
        public ActionResult<IEnumerable<Link>> GetLinksByCategory(string category)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (category == "all")
                return Ok(_context.Links.Where(x => x.Content == null && x.Course == null).ToList());
            else if (category == "faculty")
            {
                var faculty = _context.Faculties.FirstOrDefault(x=> x == profile.Groups.FirstOrDefault().Stream.SpecialityCourse.Speciality.EducationLevel.Faculty);
                return Ok(_context.Links.Where(x => x.Faculty == faculty).ToList());
            }
            else if (category == "university")
                return Ok(_context.Links.Where(x => x.IsUniversity == true).ToList());
                
            return Ok();
        }

        [HttpGet("linksfavorite")]
        public ActionResult<IEnumerable<Link>> GetLinksFavorite()
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.Links.Where(x => x.FavoriteProfiles.Contains(profile)).ToList());
        }


    }
}

