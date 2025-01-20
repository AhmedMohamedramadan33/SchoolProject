using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Authentication.Command.Models
{
    public class ChangePassword : IRequest<Response<string>>
    {
        public string id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
