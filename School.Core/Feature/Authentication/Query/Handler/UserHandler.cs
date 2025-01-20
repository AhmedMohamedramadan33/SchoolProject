using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Core.Base;
using School.Core.Feature.Authentication.Query.Models;
using School.Core.Feature.Authentication.Query.Results;
using School.Core.Paginated;
using School.Data.Entities.Identity;

namespace School.Core.Feature.Authentication.Query.Handler
{
    public class UserHandler(IMapper mapper, UserManager<AppUser> usermanager) : ResponseHandler,
        IRequestHandler<GetAllUser, PaginatedResponse<GetUsers>>,
        IRequestHandler<GetUserById, Response<GetUsers>>

    {
        UserManager<AppUser> _usermanager = usermanager;
        private readonly IMapper _mapper = mapper;
        public async Task<PaginatedResponse<GetUsers>> Handle(GetAllUser request, CancellationToken cancellationToken)
        {
            var AllUser = _usermanager.Users.AsQueryable();
            var mappedres = await _mapper.ProjectTo<GetUsers>(AllUser).ToPaginatedList(request.pagenumber, request.pagesize);
            return mappedres;
        }

        public async Task<Response<GetUsers>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var User = await _usermanager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (User == null) return NotFound<GetUsers>();
            var mapedres = _mapper.Map<GetUsers>(User);
            return Success(mapedres);
        }
    }
}
