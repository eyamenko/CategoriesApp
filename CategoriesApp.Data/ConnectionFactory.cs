namespace CategoriesApp.Data
{
    using System;
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

        public T Get<T>(Func<IDbConnection, T> func)
        {
            using (var connection = new SqlConnection(_connectionString))
                return func(connection);
        }
    }
}