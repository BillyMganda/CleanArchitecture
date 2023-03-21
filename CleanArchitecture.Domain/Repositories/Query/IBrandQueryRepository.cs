using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories.Query
{
    public interface IBrandQueryRepository : IQueryRepository<Brand>
    {
        // Custom operation which is not generic
        Task<IReadOnlyList<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(Guid id);       
    }
}
