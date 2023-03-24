using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class StoreCommandRepository : CommandRepository<Store>, ICommandStoreRepository
    {
        public StoreCommandRepository(OrderingContext context) : base(context)
        {

        }
    }
}
