using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using Konscious.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repository.Command
{
    public class UserCommandRepository
    {
        protected readonly OrderingContext _context;
        public UserCommandRepository(OrderingContext context)
        {
            _context = context;
        }

        public static void GeneratePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
                        
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                MemorySize = 65536,
                Iterations = 10
            };

            passwordHash = argon2.GetBytes(32);            
            passwordSalt = salt;
        }

        public static bool VerifyPassword(string password, byte[] storedPasswordHash, byte[] storedPasswordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (storedPasswordHash == null)
            {
                throw new ArgumentNullException(nameof(storedPasswordHash));
            }

            if (storedPasswordSalt == null)
            {
                throw new ArgumentNullException(nameof(storedPasswordSalt));
            }

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = storedPasswordSalt,
                DegreeOfParallelism = 4,
                MemorySize = 65536,
                Iterations = 10
            };

            byte[] computedPasswordHash = argon2.GetBytes(32);

            bool passwordsMatch = storedPasswordHash.Length == computedPasswordHash.Length;
            for (int i = 0; i < storedPasswordHash.Length && i < computedPasswordHash.Length; i++)
            {
                if (storedPasswordHash[i] != computedPasswordHash[i])
                {
                    passwordsMatch = false;
                    break;
                }
            }

            return passwordsMatch;
        }

        public async Task<GetUserDto> AddUserAsync(CreateUserDto createUser)
        {
            GeneratePasswordHashAndSalt(createUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userDto = new GetUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ModifiedDate = user.ModifiedDate
            };

            return userDto;
        }

        public async Task<bool> EditUserAsync(ModifyUserDto modifyUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == modifyUser.Id);
            if(user is not null)
            {
                user.FirstName = modifyUser.FirstName;
                user.LastName = modifyUser.LastName;
                user.Email = modifyUser.Email;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<GetUserDto>> GetAllUsersAsync()
        {
            var userDtos = await _context.Users
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ModifiedDate = u.ModifiedDate
                })
                .ToListAsync();

            return userDtos;
        }

        public async Task<GetUserDto> GetUserByIdAsync(Guid Id)
        {
            var userDto = await _context.Users
                .Where(u => u.Id == Id)
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ModifiedDate = u.ModifiedDate
                })
                .FirstOrDefaultAsync();

            return userDto!;
        }
    }
}
