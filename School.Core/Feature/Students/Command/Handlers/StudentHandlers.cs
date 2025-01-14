using AutoMapper;
using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Command.Models;
using School.Data.Entities;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Command.Handlers
{
    public class StudentHandlers : ResponseHandler, IRequestHandler<CreateStudent, Response<string>>,
        IRequestHandler<UpdateStudent, Response<string>>,
        IRequestHandler<DeleteStudent, Response<string>>
    {
        private readonly IStudentService service;
        private readonly IMapper mapper;
        public StudentHandlers(IStudentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;

        }
        public async Task<Response<string>> Handle(CreateStudent request, CancellationToken cancellationToken)
        {

            var mapped = mapper.Map<Student>(request);
            var res = await service.AddStudent(mapped);
            if (res == "Exist")
            {
                return UnprocessableEntity<string>();
            }
            else if (res == "success")
            {
                return Created("created successfully");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var curstd = await service.GetStudentById(request.DID);
            var mapped = mapper.Map(request, curstd);
            var res = await service.UpdateStudent(request.StudID, mapped);
            if (res == "notfound") return NotFound<string>();
            else if (res == "Exist") return UnprocessableEntity<string>();
            else if (res == "success") return Updated<string>();
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            var res = await service.Delete(request.id);
            if (res == "notfound") return NotFound<string>();
            else if (res == "success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
