using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
