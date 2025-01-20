using MediatR;
using School.Core.Feature.Authentication.Query.Results;
using School.Core.Paginated;

namespace School.Core.Feature.Authentication.Query.Models
{
    public class GetAllUser : IRequest<PaginatedResponse<GetUsers>>
    {
        public int pagenumber { get; set; }
        public int pagesize { get; set; }
    }
}
