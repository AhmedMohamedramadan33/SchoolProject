using AutoMapper;
using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Query.Models;
using School.Core.Feature.Students.Query.Results;
using School.Core.Paginated;
using School.Service.Abstract;


namespace School.Core.Feature.Students.Query.Handlers
{
    public class StudentHandler : ResponseHandler,
        IRequestHandler<GetStudentList, Response<List<StudentResponse>>>,
        IRequestHandler<GetStudentById, Response<StudentResponse>>,
        IRequestHandler<GetPaginatedStudent, PaginatedResponse<StudentResponse>>
    {
        private readonly IStudentService _student;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentService student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
        }

        public async Task<Response<List<StudentResponse>>> Handle(GetStudentList request, CancellationToken cancellationToken)
        {
            var res = _student.GetStudent();
            var mapped = _mapper.ProjectTo<StudentResponse>(res).ToList();
            return Success(mapped);
        }

        public async Task<Response<StudentResponse>> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            var res = await _student.GetStudentById(request.Id);
            var mapped = _mapper.Map<StudentResponse>(res);
            if (res == null)
            {
                return NotFound<StudentResponse>();
            }
            return Success(mapped);
        }

        //public async Task<PaginatedResponse<StudentResponse>> Handle(GetPaginatedStudent request, CancellationToken cancellationToken)
        //{

        //    var mappedres = _mapper.ProjectTo<StudentResponse>(_student.GetStudent());
        //    Expression<Func<StudentResponse, bool>> exsearch = !string.IsNullOrWhiteSpace(request.search) ? x => x.Name.Contains(request.search) : null;
        //    Expression<Func<StudentResponse, object>> exorder = null;
        //    Expression<Func<StudentResponse, object>> exorderdesc = null;

        //    if (request.ordering == "namedesc")
        //    {
        //        exorderdesc = x => x.Name;
        //    }
        //    else if (request.ordering == "nameasc")
        //    {
        //        exorder = x => x.Name;
        //    }
        //    return await mappedres.ToPaginatedList(request.Pagenumber, request.Pagesize, exsearch, exorder, exorderdesc);

        //}
        public async Task<PaginatedResponse<StudentResponse>> Handle(GetPaginatedStudent request, CancellationToken cancellationToken)
        {
            var ressearch = _student.Search(request.search);
            var resorder = _student.orderby(ressearch, request.ordering, request.Isdescdending);
            var mappedres = _mapper.ProjectTo<StudentResponse>(resorder);
            return await mappedres.ToPaginatedList(request.Pagenumber, request.Pagesize);
        }

    }
}
