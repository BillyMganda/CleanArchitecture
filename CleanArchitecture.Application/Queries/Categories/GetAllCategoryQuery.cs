using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Categories
{
    public class GetAllCategoryQuery : IRequest<List<Category>>
    {
    }
}
