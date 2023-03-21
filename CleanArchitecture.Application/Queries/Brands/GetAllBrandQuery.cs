using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Brands
{
    public class GetAllBrandQuery : IRequest<List<Brand>>
    {
    }
}
