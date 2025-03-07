using Common.Miscellaneous.Middleware;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Jwt.Query;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("api/v1/", Name = "Authenticate", Order = 1)]
    [Produces("application/json")]
    public class JwtController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<JwtController> _logger;
        public JwtController(IMediator mediator, ILogger<JwtController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<JwtVm> Authenticate(JwtQuery request)
        {
            var response= await _mediator.Send(request);
            return response;
        }
    }
}
