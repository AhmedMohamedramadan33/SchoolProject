using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Students.Command.Models
{
    public class DeleteStudent : IRequest<Response<string>>
    {
        public int id { get; set; }

        public DeleteStudent(int id)
        {
            this.id = id;
        }
    }
}
