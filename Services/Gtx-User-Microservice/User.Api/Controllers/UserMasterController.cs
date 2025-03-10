using Common.Miscellaneous.Middleware;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.UserMaster.Command.AddUserMaster;
using User.Application.Features.UserMaster.GetUsersList;
using User.Application.Features.UserMaster.Query;

namespace User.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserMasterController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserMasterController> _logger;
        public UserMasterController(IMediator mediator, ILogger<UserMasterController> logger)
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
        public async Task<UserMasterVm> Authenticate(UserMasterQuery request)
        {
            var response= await _mediator.Send(request);
            return response;
        }


        
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("getUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<GetUserVm> GetUsers(int pageNumber, int pagesize)
        {
            var request = new GetUserQuery { PageNumber = pageNumber, PageSize = pagesize };
            var response = await _mediator.Send(request);
            return response;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<AddUserMasterVm> AddUser([FromBody]  AddUserMasterCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
