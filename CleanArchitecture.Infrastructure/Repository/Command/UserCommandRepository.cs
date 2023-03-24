using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class UserCommandRepository
    {
        protected readonly OrderingContext _context;
        public UserCommandRepository(OrderingContext context)
        {
            _context = context;
        }
    }
}
