using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public Guid Id { get; private set; }

        public DeleteCustomerCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
