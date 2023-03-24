using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Stores
{
    public class GetStoreByIdQuery : IRequest<Store>
    {
        public Guid Id { get; private set; }
        public GetStoreByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
