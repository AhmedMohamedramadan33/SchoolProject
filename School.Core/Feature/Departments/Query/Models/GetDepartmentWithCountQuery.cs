using MediatR;
using School.Core.Base;
using School.Core.Feature.Departments.Query.Results;

namespace School.Core.Feature.Departments.Query.Models
{
    public class GetDepartmentWithCountQuery : IRequest<Response<List<GetDepartmentWithstudentCountResult>>>
    {

    }
}
