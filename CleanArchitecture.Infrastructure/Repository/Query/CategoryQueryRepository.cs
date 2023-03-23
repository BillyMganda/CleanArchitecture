using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using CleanArchitecture.Infrastructure.Repository.Query.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CleanArchitecture.Infrastructure.Repository.Query
{
    public class CategoryQueryRepository : QueryRepository<Category>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM CATEGORIES";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Category>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            try
            {
                var query = "SELECT * FROM CATEGORIES WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Guid);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Category>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
