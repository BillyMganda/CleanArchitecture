using MediatR;

namespace CleanArchitecture.Application.Commands.Brands
{
    public class DeleteBrandCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteBrandCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
