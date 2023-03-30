using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories.Query
{
    public interface IUserQueryRepository : IQueryRepository<User>
    {
        // Custom operation which is not generic
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
    }
}
