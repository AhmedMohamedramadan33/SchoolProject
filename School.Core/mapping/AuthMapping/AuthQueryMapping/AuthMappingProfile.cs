using AutoMapper;
using School.Core.Feature.Authentication.Query.Results;
using School.Data.Entities.Identity;

namespace School.Core.mapping.AuthMapping
{
    public partial class AuthMappingProfile : Profile
    {
        public void ApplyAuthqueryMapping()
        {
            CreateMap<AppUser, GetUsers>();
        }
    }
}
