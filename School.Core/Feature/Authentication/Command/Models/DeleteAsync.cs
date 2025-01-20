using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Authentication.Command.Models
{
    public class DeleteAsync : IRequest<Response<string>>
    {
        public string Id { get; set; }

        public DeleteAsync(string id)
        {
            Id = id;
        }
    }
}
