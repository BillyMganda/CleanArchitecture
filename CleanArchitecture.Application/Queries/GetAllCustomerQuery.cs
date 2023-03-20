using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
    }
}
