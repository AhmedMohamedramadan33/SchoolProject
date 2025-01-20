using MediatR;
using School.Core.Base;
using School.Core.Feature.Authentication.Query.Results;

namespace School.Core.Feature.Authentication.Query.Models
{
    public class GetUserById : IRequest<Response<GetUsers>>
    {
        public string Id { get; set; }

        public GetUserById(string id)
        {
            Id = id;
        }
    }
}
