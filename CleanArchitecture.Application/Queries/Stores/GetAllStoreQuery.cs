using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Stores
{
    public class GetAllStoreQuery : IRequest<List<Store>>
    {
    }
}
