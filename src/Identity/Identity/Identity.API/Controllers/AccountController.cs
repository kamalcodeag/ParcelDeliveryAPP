using Identity.Logic.Features.Users.Commands.CreateUser;
using Identity.Logic.Features.Users.Queries.GetCourierUsers;
using Identity.Logic.Features.Users.Queries.GetUserWithRolePermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<GetUserWithRolePermissionsQueryResponse>> Login([FromBody] GetUserWithRolePermissionsQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<CreateUserCommandResponse>> RegisterAsync([FromBody] CreateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("couriers")]
        public async Task<ActionResult<List<GetCourierUsersQueryResponse>>> GetAllCourierUsersAsync()
        {
            return Ok(await _mediator.Send(new GetCourierUsersQuery()));
        }
    }
}