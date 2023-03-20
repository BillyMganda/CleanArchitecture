using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories.Query
{
    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> GetCustomerByEmail(string email);
    }
}
