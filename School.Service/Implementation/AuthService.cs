using Microsoft.AspNetCore.Identity;
using School.Data.Entities.Identity;
using School.Service.Abstract;

namespace School.Service.Implementation
{
    internal class AuthService(UserManager<AppUser> userManager) : IAuthService
    {




    }
}
