using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class CategoryCommandRepository : CommandRepository<Category>, ICommandCategoryRepository
    {
        public CategoryCommandRepository(OrderingContext context) : base(context)
        {

        }
    }
}
