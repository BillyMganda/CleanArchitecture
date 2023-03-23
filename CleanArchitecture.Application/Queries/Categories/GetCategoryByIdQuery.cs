using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Categories
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public Guid Id { get; private set; }
        public GetCategoryByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
