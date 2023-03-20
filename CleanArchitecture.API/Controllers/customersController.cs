using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public customersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Customer>> Get()
        {
            return await _mediator.Send(new GetAllCustomerQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Customer> Get(Guid id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(id));
        }

        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Customer> GetByEmail(string email)
        {
            return await _mediator.Send(new GetCustomerByEmailQuery(email));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> EditCustomer(Guid id, [FromBody] EditCustomerCommand command)
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
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteCustomerCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
