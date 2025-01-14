using AutoMapper;

namespace School.Core.mapping.DepartmentMapping
{
    public partial class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            AddDepartmentQueryMapping();
        }
    }
}
