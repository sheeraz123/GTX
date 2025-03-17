using Common.Miscellaneous.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.ProductMasters.Command.AddProductMaster;
using User.Application.Features.ProductMasters.Command.UpdateProductMaster;
using User.Application.Features.ProductMasters.Query.GetProductMaster;

namespace User.Api.Controllers
{
    [Route("api/ProductMaster")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductMasterController> _logger;
        public ProductMasterController(IMediator mediator, ILogger<ProductMasterController> logger)
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
        public async Task<AddProductMasterVm> AddProductMaster([FromForm] AddProductMasterCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> UpdateProductMaster([FromBody] UpdateProductMasterCommand command)
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
        public async Task<IActionResult> GetProductMaster(int pageNumber, int pagesize, string search = "", int id = 0)
        {
            var query = new GetProductMasterQuery { PageNumber = pageNumber, PageSize = pagesize, Search = search, Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
