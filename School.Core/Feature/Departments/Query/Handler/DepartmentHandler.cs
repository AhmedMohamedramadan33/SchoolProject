using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Departments.Query.Models;
using School.Core.Feature.Departments.Query.Results;
using School.Core.Paginated;
using School.Core.Resources;
using School.Data.Entities;
using School.Data.Procedures;
using School.Service.Abstract;
using System.Linq.Expressions;

namespace School.Core.Feature.Departments.Query.Handler
{
    public class DepartmentHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentWithCountQuery, Response<List<GetDepartmentWithstudentCountResult>>>,
        IRequestHandler<GetDepartmentwithproc, Response<GetDepartmentWithProcResult>>

    {
        private readonly IDepartmentService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly IStudentService _student;
        private readonly IDepartmentWithCountService _DepWithCountService;
        private readonly IDepartmentProc _proc;
        public DepartmentHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, IDepartmentService service,
            IStudentService student, IDepartmentWithCountService DepWithCountService, IDepartmentProc proc)
        {
            _mapper = mapper;
            _localizer = localizer;
            _service = service;
            _student = student;
            _DepWithCountService = DepWithCountService;
            _proc = proc;
        }
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _service.GetDepartmentById(request.Id);
            if (res == null) return NotFound<GetDepartmentByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);
            var mappedres = _mapper.Map<GetDepartmentByIdResponse>(res);
            Expression<Func<Student, StudentResponse>> exp = e => new StudentResponse(e.StudID, e.Name);
            var studres = _student.GetByDepartment(request.Id);
            var paginatedres = await studres.Select(exp).ToPaginatedList(request.StudentPageNumber, request.StudentPageSize);
            mappedres.Students = paginatedres;
            return Success(mappedres);
        }

        public async Task<Response<List<GetDepartmentWithstudentCountResult>>> Handle(GetDepartmentWithCountQuery request, CancellationToken cancellationToken)
        {
            var res = _DepWithCountService._GetDepartmentwithstudentcount();
            var mappedres = _mapper.ProjectTo<GetDepartmentWithstudentCountResult>(res).ToList();
            return Success(mappedres);
        }

        public async Task<Response<GetDepartmentWithProcResult>> Handle(GetDepartmentwithproc request, CancellationToken cancellationToken)
        {
            var mapparam = _mapper.Map<GetDepartmentWithStdCountProcparam>(request);
            var res = await _proc.getDepartmentWithStdCountProcs(mapparam);
            var result = _mapper.Map<GetDepartmentWithProcResult>(res);
            return Success(result);
        }
    }
}
