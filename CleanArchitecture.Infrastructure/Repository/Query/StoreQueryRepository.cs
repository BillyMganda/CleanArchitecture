using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using CleanArchitecture.Infrastructure.Repository.Query.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CleanArchitecture.Infrastructure.Repository.Query
{
    public class StoreQueryRepository : QueryRepository<Store>, IStoreQueryRepository
    {
        public StoreQueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Store>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM STORES";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Store>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Store> GetByIdAsync(Guid id)
        {
            try
            {
                var query = "SELECT * FROM STORES WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Guid);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Store>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
