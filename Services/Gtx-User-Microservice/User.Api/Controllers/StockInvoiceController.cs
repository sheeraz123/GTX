using Common.Miscellaneous.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Stocks.StockInvoices.Query.GetData;
using User.Application.Features.Stocks.StockInvoices.Command.Add;
using User.Application.Features.Stocks.StockInvoices.Command.Update;

namespace User.Api.Controllers
{
    [Route("api/StockInvoice")]
    [ApiController]
    public class StockInvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StockInvoiceController> _logger;
        public StockInvoiceController(IMediator mediator, ILogger<StockInvoiceController> logger)
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
        public async Task<AddVm> Add([FromForm] AddCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

       
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> Update([FromForm] UpdateCommand command)
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
            var query = new GetQuery { PageNumber = pageNumber, PageSize = pagesize, Search = search, Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
