using AutoMapper;
using School.Core.Feature.Authentication.Command.Models;
using School.Data.Entities.Identity;

namespace School.Core.mapping.AuthMapping
{
    public partial class AuthMappingProfile : Profile
    {
        public void ApplyAuthCommandMapping()
        {
            CreateMap<RegisterUser, AppUser>();
            CreateMap<UpdateAsync, AppUser>();

        }
    }
}