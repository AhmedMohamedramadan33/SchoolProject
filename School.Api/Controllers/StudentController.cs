using Microsoft.AspNetCore.Mvc;
using School.Core.Feature.Students.Command.Models;
using School.Core.Feature.Students.Query.Models;
using School.Data.Route;

namespace School.Api.Controllers
{
    [ApiController]
    public class StudentController : BaseController
    {

        [HttpGet(BaseRoute.studentrouting.getlist)]
        public async Task<IActionResult> get()
        {
            var res = await _mediator.Send(new GetStudentList());
            return Ok(res);
        }
        [HttpGet(BaseRoute.studentrouting.getbyid)]
        public async Task<IActionResult> Get(int id)
        {
            return NewResult(await _mediator.Send(new GetStudentById(id)));
        }
        [HttpGet(BaseRoute.studentrouting.GetPaginatedStudent)]
        public async Task<IActionResult> Get([FromQuery] GetPaginatedStudent getPaginatedStudent)
        {
            return Ok(await _mediator.Send(getPaginatedStudent));
        }
        [HttpPost(BaseRoute.studentrouting.AddStudent)]
        public async Task<ActionResult> Add(CreateStudent student)
        {
            return NewResult(await _mediator.Send(student));
        }
        [HttpPut(BaseRoute.studentrouting.UpdateStudent)]
        public async Task<ActionResult> Update(UpdateStudent student)
        {
            return NewResult(await _mediator.Send(student));
        }
        [HttpDelete(BaseRoute.studentrouting.DeleteStudent)]
        public async Task<ActionResult> Update(int id)
        {
            return NewResult(await _mediator.Send(new DeleteStudent(id)));
        }
    }
}
