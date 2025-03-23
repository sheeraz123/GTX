using Common.Miscellaneous.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Misc.ColorMasters.Command.Add;
using User.Application.Features.Misc.ColorMasters.Command.Update;
using User.Application.Features.Misc.ColorMasters.Query.GetData;
namespace User.Api.Controllers
{
    [Route("api/ColorMaster")]
    [ApiController]
    public class ColorMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ColorMasterController> _logger;
        public ColorMasterController(IMediator mediator, ILogger<ColorMasterController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> Add([FromBody] AddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
       
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> Update([FromBody] UpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> Get(int pageNumber, int pagesize, string search = "", int id = 0)
        {
            var request = new GetQuery { PageNumber = pageNumber, PageSize = pagesize, Search = search, Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
