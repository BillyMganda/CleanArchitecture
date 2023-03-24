using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories.Query
{
    public interface IStoreQueryRepository : IQueryRepository<Store>
    {
        // Custom operation which is not generic
        Task<IReadOnlyList<Store>> GetAllAsync();
        Task<Store> GetByIdAsync(Guid id);
    }
}
