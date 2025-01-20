using Microsoft.AspNetCore.Identity;

namespace School.Data.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
    }
}
