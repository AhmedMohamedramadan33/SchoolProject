using School.Core.Feature.Students.Query.Results;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Feature.mapping
{
    public partial class StudentMapping
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, StudentResponse>().
                ForMember(des => des.Department, x => x.MapFrom(src => src.Department.DName));
        }
    }
}
