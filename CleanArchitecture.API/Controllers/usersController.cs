using CleanArchitecture.Domain.DTOs.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Commands;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public usersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            var dto = new GetUserDto
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                ModifiedDate = result.ModifiedDate
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var command = new CreateUserCommand
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                ConfirmPassword = dto.ConfirmPassword
            };

            var result = await _mediator.Send(command);

            var createdDto = new GetUserDto
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                ModifiedDate = result.ModifiedDate
            };

            return CreatedAtAction(nameof(Get), new { id = result.Id }, createdDto);
        }
    }
}
