using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Students.Command.Models
{
    public class UpdateStudent : IRequest<Response<string>>
    {
        public int StudID { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        public int DID { get; set; }
    }
}
