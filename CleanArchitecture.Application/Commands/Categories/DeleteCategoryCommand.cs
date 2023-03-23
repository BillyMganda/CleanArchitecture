using MediatR;

namespace CleanArchitecture.Application.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteCategoryCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
