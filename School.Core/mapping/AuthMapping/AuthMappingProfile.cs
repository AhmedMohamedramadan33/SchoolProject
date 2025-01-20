using AutoMapper;

namespace School.Core.mapping.AuthMapping
{
    public partial class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            ApplyAuthCommandMapping();
            ApplyAuthqueryMapping();
        }
    }
}
