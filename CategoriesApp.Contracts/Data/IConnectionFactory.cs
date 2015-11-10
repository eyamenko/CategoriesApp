namespace CategoriesApp.Contracts.Data
{
    using System;
    using System.Data;

    public interface IConnectionFactory
    {
        T Get<T>(Func<IDbConnection, T> func);
    }
}