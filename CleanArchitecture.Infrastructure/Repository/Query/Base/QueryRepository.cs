using CleanArchitecture.Domain.Repositories.Query;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Repository.Query.Base
{
    public class QueryRepository<T> : DbConnector,  IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
