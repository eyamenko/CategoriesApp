namespace CategoriesApp.Contracts.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface ICategoriesService
    {
        Task<bool> Create(Category category);
        Task<bool> Delete(int id);
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(int id);
        Task<bool> Update(Category category);
        Task<IEnumerable<Category>> GetRoot();
        Task<IEnumerable<Category>> GetChildren(int id);
    }
}