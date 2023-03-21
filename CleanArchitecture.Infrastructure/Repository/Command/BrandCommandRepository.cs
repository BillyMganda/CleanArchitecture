using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class BrandCommandRepository : CommandRepository<Brand>, ICommandBrandRepository
    {
        public BrandCommandRepository(OrderingContext context) : base(context)
        {

        }
    }
}
