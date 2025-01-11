using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Query.Results;

namespace School.Core.Feature.Students.Query.Models
{
   public class GetStudentList:IRequest<Response<List<StudentResponse>>>
    {

    }
}
