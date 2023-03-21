using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using CleanArchitecture.Infrastructure.Repository.Query.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CleanArchitecture.Infrastructure.Repository.Query
{
    public class BrandQueryRepository : QueryRepository<Brand>, IBrandQueryRepository
    {
        public BrandQueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Brand>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM BRANDS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Brand>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            try
            {
                var query = "SELECT * FROM BRANDS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Guid);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Brand>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
