using CleanArchitecture.Domain.DTOs.Users;
using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public class CreateUserCommand : IRequest<GetUserDto>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
