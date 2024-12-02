using UniverSum.API.Identity;
using UniverSum.API.Models;

namespace UniverSum.API
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void TieIdentityAndProfile(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            var profile = _context.Profiles.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.ProfileId = profile.Id;
                profile.IdentityId = user.Id;
            }
        }
    }
}
