using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class CustomerCommandRepository : CommandRepository<Customer>, ICommandCustomerRepository
    {
        public CustomerCommandRepository(OrderingContext context) : base(context)
        {

        }
    }
}
