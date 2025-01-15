using MediatR;
using School.Core.Base;
using School.Core.Feature.Departments.Query.Results;

namespace School.Core.Feature.Departments.Query.Models
{
    public class GetDepartmentwithproc : IRequest<Response<GetDepartmentWithProcResult>>
    {
        public int did { get; set; }

    }
}
