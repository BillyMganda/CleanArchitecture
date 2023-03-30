using CleanArchitecture.Domain.DTOs.Users;
using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public class ModifyUserCommand : IRequest<GetUserDto>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
