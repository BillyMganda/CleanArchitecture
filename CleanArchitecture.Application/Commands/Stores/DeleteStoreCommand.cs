using MediatR;

namespace CleanArchitecture.Application.Commands.Stores
{
    public class DeleteStoreCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteStoreCommand(Guid id)
        {
            Id = id;
        }
    }
}
