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
    }
}
