using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories.Query
{
    public interface ICategoryQueryRepository : IQueryRepository<Category>
    {
        // Custom operation which is not generic
        Task<IReadOnlyList<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
    }
}
