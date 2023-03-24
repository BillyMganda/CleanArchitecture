using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using CleanArchitecture.Infrastructure.Repository.Query.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CleanArchitecture.Infrastructure.Repository.Query
{
    public class UserQueryRepository : QueryRepository<Store>, IUserQueryRepository
    {
        public UserQueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM USERS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<User>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            try
            {
                var query = "SELECT * FROM USERS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Guid);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<User>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
