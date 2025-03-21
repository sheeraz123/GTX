using Common.Miscellaneous.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Stocks.StockCategories.Command.Add;
using User.Application.Features.Stocks.StockCategories.Command.Update;
using User.Application.Features.Stocks.StockCategories.Query.GetData;

namespace User.Api.Controllers
{
    [Route("api/StockCategory")]
    [ApiController]
    public class StockCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StockCategoryController> _logger;
        public StockCategoryController(IMediator mediator, ILogger<StockCategoryController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Consumes("application/json")]
        [Produces("application/json")]
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
        [Consumes("application/json")]
        [Produces("application/json")]
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
