using Microsoft.AspNetCore.Mvc;
using School.Core.Feature.Authentication.Command.Models;
using School.Core.Feature.Authentication.Query.Models;
using School.Data.Route;

namespace School.Api.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost(BaseRoute.AuthRouting.Register)]
        public async Task<IActionResult> Register(RegisterUser register)
        {
            return NewResult(await _mediator.Send(register));
        }
        [HttpGet(BaseRoute.AuthRouting.getlist)]
        public async Task<IActionResult> GetList([FromQuery] GetAllUser getAll)
        {
            return Ok(await _mediator.Send(new GetAllUser() { pagenumber = getAll.pagenumber, pagesize = getAll.pagesize }));
        }
        [HttpGet(BaseRoute.AuthRouting.getbyid)]
        public async Task<IActionResult> GetById(string id)
        {
            return NewResult(await _mediator.Send(new GetUserById(id)));
        }
        [HttpPut(BaseRoute.AuthRouting.Update)]
        public async Task<IActionResult> Update(UpdateAsync update)
        {
            return NewResult(await _mediator.Send(update));
        }
        [HttpDelete(BaseRoute.AuthRouting.Update)]
        public async Task<IActionResult> Delete(string id)
        {
            return NewResult(await _mediator.Send(new DeleteAsync(id)));
        }
        [HttpPut(BaseRoute.AuthRouting.Changepassword)]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            return NewResult(await _mediator.Send(changePassword));
        }
    }
}
