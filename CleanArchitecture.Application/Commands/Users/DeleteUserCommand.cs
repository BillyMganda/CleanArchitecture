using MediatR;

namespace CleanArchitecture.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
