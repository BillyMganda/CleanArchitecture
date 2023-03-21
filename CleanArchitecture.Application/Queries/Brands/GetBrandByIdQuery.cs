using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Brands
{
    public class GetBrandByIdQuery : IRequest<Brand>
    {
        public Guid Id { get; private set; }
        public GetBrandByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
