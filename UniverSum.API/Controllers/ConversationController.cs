using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniverSum.API.Identity;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Schedule;

namespace UniverSum.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public ConversationController(ApplicationDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("conversation")]
        public ActionResult<Conversation> GetConversation(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.Conversations.Where(x => x.Id == id
            && x.Members.Contains(profile)).FirstOrDefault());
        }

        [HttpGet("conversations")]
        public ActionResult<IEnumerable<Conversation>> GetConversations()
        {
            var profile = _context.Profiles.FirstOrDefault(x => x.IdentityId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_context.Conversations.Where(x=> x.Members.Contains(profile)).FirstOrDefault());
        }
    }
}
