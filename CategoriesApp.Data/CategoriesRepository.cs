namespace CategoriesApp.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Data;
    using Models;
    using Primitives;

    public class CategoriesRepository : BaseRepository, ICategoriesRepository
    {
        private const string Db = "dbo.Categories";

        public CategoriesRepository(IConnectionFactory connectionFactory) : base(connectionFactory) {}

        public async Task<IEnumerable<Category>> Get()
        {
            var sql = $"SELECT * FROM {Db};";

            return await Query<Category>(sql);
        }

        public async Task<Category> Get(int id)
        {
            var sql = $"SELECT * FROM {Db} WHERE Id = @id;";

            return await QuerySingle<Category>(sql, new {id});
        }

        public async Task<bool> Create(Category category)
        {
            var sql = $"INSERT INTO {Db} (Name, ParentId) VALUES (@Name, @ParentId);";

            return await Execute(sql, category);
        }

        public async Task<bool> Update(Category category)
        {
            var sql = $"UPDATE {Db} SET Name = @Name, ParentId = @ParentId WHERE Id = @Id;";

            return await Execute(sql, category);
        }

        public async Task<bool> Delete(int id)
        {
            var sql = $"DELETE FROM {Db} WHERE Id = @id;";

            return await Execute(sql, new {id});
        }

        public async Task<IEnumerable<Category>> GetRoot()
        {
            var sql = $"SELECT * FROM {Db} WHERE ParentId IS NULL;";

            return await Query<Category>(sql);
        }

        public async Task<IEnumerable<Category>> GetChildren(int id)
        {
            var sql = $"SELECT * FROM {Db} WHERE ParentId = @id;";

            return await Query<Category>(sql, new {id});
        }
    }
}