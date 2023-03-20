using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; private set; }

        public GetCustomerByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
