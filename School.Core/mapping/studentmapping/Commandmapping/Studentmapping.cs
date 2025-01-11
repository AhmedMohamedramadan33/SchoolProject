using School.Core.Feature.Students.Command.Models;
using School.Data.Entities;

namespace School.Core.Feature.mapping
{
    public partial class StudentMapping
    {
        public void CreateStudentMapping()
        {
            CreateMap<CreateStudent, Student>();
            CreateMap<UpdateStudent, Student>();
        }
    }
}
