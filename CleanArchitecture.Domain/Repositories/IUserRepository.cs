using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
