namespace CategoriesApp.Data.Primitives
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts.Data;
    using Dapper;

    public class BaseRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected async Task<TEntity> QuerySingle<TEntity>(string sql, object param = null)
        {
            return (await this.Query<TEntity>(sql, param)).SingleOrDefault();
        }

        protected async Task<IEnumerable<TEntity>> Query<TEntity>(string sql, object param = null)
        {
            using (var connection = _connectionFactory.Get())
                return await connection.QueryAsync<TEntity>(sql, param);
        }

        protected async Task<bool> Execute(string sql, object param = null)
        {
            using (var connection = _connectionFactory.Get())
                return await connection.ExecuteAsync(sql, param) > 0;
        }
    }
}