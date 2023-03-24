using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Commands.Stores;
using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Application.Queries.Stores;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class storesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public storesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Store>> Get()
        {
            return await _mediator.Send(new GetAllStoreQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Store> Get(Guid id)
        {
            return await _mediator.Send(new GetStoreByIdQuery(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StoreResponse>> CreateBrand([FromBody] CreateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditStore(Guid id, [FromBody] EditStoreCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStore(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteStoreCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
