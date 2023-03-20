using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class CommandCustomerRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(OrderingContext context) : base(context)
        {

        }
    }
}
