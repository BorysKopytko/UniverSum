using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UniverSum.API.Models;

namespace UniverSum.API.Identity
{
    public class CustomUser : IdentityUser
    {
        public int ProfileId { get; set; }
    }
}
