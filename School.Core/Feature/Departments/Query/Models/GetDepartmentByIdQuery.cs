using MediatR;
using School.Core.Base;
using School.Core.Feature.Departments.Query.Results;

namespace School.Core.Feature.Departments.Query.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }

    }
}
