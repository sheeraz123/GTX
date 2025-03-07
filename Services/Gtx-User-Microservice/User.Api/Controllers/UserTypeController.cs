using Common.Miscellaneous.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Jwt.Query;
using User.Application.Features.UserType.Query;

namespace User.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserTypeController> _logger;

        public UserTypeController(IMediator mediator, ILogger<UserTypeController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("UserTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<IReadOnlyList<GetUserTypeVm>> GetUserTypes()
        {
            var request = new GetUserTypeQuery();
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
