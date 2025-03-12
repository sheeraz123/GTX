using Common.Miscellaneous.Middleware;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.ClientMaster.Query;
using User.Application.Features.CompanyMaster.Query;
using User.Application.Features.UserMaster.GetUsersList;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status502BadGateway)]
        public async Task<GetCompanyVm> GetCompany(int pageNumber, int pagesize, int id = 0)
        {
            var request = new GetCompanyQuery { PageNumber = pageNumber, PageSize = pagesize, Id = id };
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
