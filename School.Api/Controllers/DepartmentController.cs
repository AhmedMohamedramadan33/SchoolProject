using Microsoft.AspNetCore.Mvc;
using School.Core.Feature.Departments.Query.Models;
using School.Data.Route;

namespace School.Api.Controllers
{
    [ApiController]
    public class DepartmentController : BaseController
    {
        [HttpGet(BaseRoute.departmentrouting.getbyid)]
        public async Task<IActionResult> GetByid([FromQuery] GetDepartmentByIdQuery request)
        {
            return NewResult(await _mediator.Send(request));
        }
        [HttpGet(BaseRoute.departmentrouting.getdepartmentwithstdcount)]
        public async Task<IActionResult> Getdepartmentwithcount()
        {
            return NewResult(await _mediator.Send(new GetDepartmentWithCountQuery()));
        }
        [HttpGet(BaseRoute.departmentrouting.getspecificdepartmentwithstdcount)]
        public async Task<IActionResult> GetSpecficdepartmentwithcount(int id)
        {
            return NewResult(await _mediator.Send(new GetDepartmentwithproc() { did = id }));
        }
    }
}
