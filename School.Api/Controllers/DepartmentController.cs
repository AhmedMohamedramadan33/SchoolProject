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

    }
}
