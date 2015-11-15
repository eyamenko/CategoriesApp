namespace CategoriesApp.Contracts.Data
{
    using System.Data;

    public interface IConnectionFactory
    {
        IDbConnection Get();
    }
}