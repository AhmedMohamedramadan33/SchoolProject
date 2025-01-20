using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Core.Base;
using School.Core.Feature.Authentication.Command.Models;
using School.Data.Entities.Identity;

namespace School.Core.Feature.Authentication.Command.Handlers
{
    public class AuthHandler(IMapper mapper, UserManager<AppUser> usermanager) : ResponseHandler, IRequestHandler<RegisterUser, Response<string>>,
        IRequestHandler<UpdateAsync, Response<string>>,
        IRequestHandler<DeleteAsync, Response<string>>,
        IRequestHandler<ChangePassword, Response<string>>


    {
        UserManager<AppUser> _usermanager = usermanager;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<string>> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var isexist = await _usermanager.Users.AnyAsync(x => x.UserName == request.UserName || x.Email == request.Email);
            if (isexist) return BadRequest<string>();
            var mapped = _mapper.Map<AppUser>(request);
            var res = await _usermanager.CreateAsync(mapped, request.Password);
            if (!res.Succeeded) return BadRequest<string>();
            return Success("registerd successfully");
        }

        public async Task<Response<string>> Handle(UpdateAsync request, CancellationToken cancellationToken)
        {
            var user = await _usermanager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) return NotFound<string>();
            var isexist = await _usermanager.Users.AnyAsync(x => (x.Email == request.Email || x.UserName == request.UserName) && (x.Id != request.Id));
            if (isexist) return BadRequest<string>();
            _mapper.Map(request, user);
            var res = await _usermanager.UpdateAsync(user);
            if (!res.Succeeded) return BadRequest<string>();
            return Success("Updated Successfully");
        }

        public async Task<Response<string>> Handle(DeleteAsync request, CancellationToken cancellationToken)
        {
            var user = await _usermanager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) return NotFound<string>();
            var res = await _usermanager.DeleteAsync(user);
            if (!res.Succeeded) return BadRequest<string>();
            return Success("Updated Successfully");
        }

        public async Task<Response<string>> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _usermanager.Users.FirstOrDefaultAsync(x => x.Id == request.id);
            if (user == null) return NotFound<string>();
            var res = await _usermanager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!res.Succeeded) return BadRequest<string>();
            return Success("Updated Successfully");
        }
    }
}
