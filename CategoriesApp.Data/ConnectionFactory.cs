namespace CategoriesApp.Data
{
    using System.Data;
    using System.Data.SqlClient;
    using Contracts.Data;

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Get()
        {
            return new SqlConnection(_connectionString);
        }
    }
}