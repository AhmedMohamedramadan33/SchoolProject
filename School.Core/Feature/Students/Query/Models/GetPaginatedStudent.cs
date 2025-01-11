using MediatR;
using School.Core.Feature.Students.Query.Results;
using School.Core.Paginated;
using School.Data.Sorting;

namespace School.Core.Feature.Students.Query.Models
{
    public class GetPaginatedStudent : IRequest<PaginatedResponse<StudentResponse>>
    {


        public int Pagenumber { get; set; }
        public int Pagesize { get; set; }
        public StudentSorting? ordering { get; set; }
        public string? search { get; set; }
        public bool? Isdescdending { get; set; }
    }
}
