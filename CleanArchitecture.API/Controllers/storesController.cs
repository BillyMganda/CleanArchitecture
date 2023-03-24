using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Application.Queries.Stores;
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
    }
}
