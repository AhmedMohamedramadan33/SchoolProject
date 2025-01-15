using School.Core.Feature.Departments.Query.Models;
using School.Core.Feature.Departments.Query.Results;
using School.Data.Entities;
using School.Data.Localization;
using School.Data.Procedures;

namespace School.Core.mapping.DepartmentMapping
{
    public partial class DepartmentMappingProfile
    {
        public void AddDepartmentQueryMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>().
              ForMember(desc => desc.DID, x => x.MapFrom(src => src.DID)).
              ForMember(desc => desc.DName, x => x.MapFrom(src => src.DName)).
              ForMember(desc => desc.ManagerName, x => x.MapFrom(src => LocalizableEntity.localize(src.Instructor.ENameAr, src.Instructor.ENameEn))).
              ForMember(desc => desc.Subjects, x => x.MapFrom(src => src.DepartmentSubjects)).
              ForMember(desc => desc.Students, opt => opt.Ignore()).
              ForMember(desc => desc.Instructors, x => x.MapFrom(src => src.Instructors));
            CreateMap<DepartmetSubject, SubjectResponse>().
                 ForMember(desc => desc.ID, x => x.MapFrom(src => src.SubID)).
                 ForMember(desc => desc.Name, x => x.MapFrom(src => LocalizableEntity.localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            CreateMap<Instructor, InstructResponse>().
                 ForMember(desc => desc.ID, x => x.MapFrom(src => src.InsId)).
                 ForMember(desc => desc.Name, x => x.MapFrom(src => LocalizableEntity.localize(src.ENameAr, src.ENameEn)));

            CreateMap<GetDepartmentwithstudentcount, GetDepartmentWithstudentCountResult>();

            CreateMap<GetDepartmentWithStdCountProc, GetDepartmentWithProcResult>();

            CreateMap<GetDepartmentwithproc, GetDepartmentWithStdCountProcparam>();



        }
    }
}
