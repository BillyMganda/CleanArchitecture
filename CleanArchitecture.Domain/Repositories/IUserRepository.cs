using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<GetUserDto> GetByIdAsync(Guid id);
        Task<GetUserDto> GetByEmailAsync(string email);
        Task AddAsync(CreateUserDto user);
        Task UpdateAsync(ModifyUserDto user);
        Task DeleteAsync(Guid id);
    }
}
