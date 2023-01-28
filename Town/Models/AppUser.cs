using Microsoft.AspNetCore.Identity;

namespace Town.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
