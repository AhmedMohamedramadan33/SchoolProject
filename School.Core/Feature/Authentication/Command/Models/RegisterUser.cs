using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Authentication.Command.Models
{
    public class RegisterUser : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }

    }
}
