namespace CategoriesApp.Tests.Data
{
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CategoriesApp.Data;
    using Contracts.Data;
    using Dapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class CategoriesRepositoryTests
    {
        private const string Db = "dbo.Categories";
        private ICategoriesRepository _categoriesRepository;
        private IConnectionFactory _connectionFactory;

        [TestInitialize]
        public void Initialize()
        {
            _connectionFactory = new ConnectionFactory(ConfigurationManager.AppSettings["CategoriesAppDb"]);
            _categoriesRepository = new CategoriesRepository(_connectionFactory);

            var sql = new StringBuilder();

            sql.Append($"DELETE FROM {Db};");
            sql.Append($"SET IDENTITY_INSERT {Db} ON;");
            sql.Append($"INSERT INTO {Db} ([Id], [Name], [ParentId]) VALUES (1, N'Category1', NULL);");
            sql.Append($"INSERT INTO {Db} ([Id], [Name], [ParentId]) VALUES (2, N'Category2', 1);");
            sql.Append($"INSERT INTO {Db} ([Id], [Name], [ParentId]) VALUES (3, N'Category3', NULL);");
            sql.Append($"INSERT INTO {Db} ([Id], [Name], [ParentId]) VALUES (4, N'Category4', 2);");
            sql.Append($"SET IDENTITY_INSERT {Db} OFF;");

            using (var connection = _connectionFactory.Get())
                connection.Execute(sql.ToString());
        }

        [TestCleanup]
        public void Cleanup()
        {
            var sql = $"DELETE FROM {Db};";

            using (var connection = _connectionFactory.Get())
                connection.Execute(sql);
        }

        [TestMethod]
        public async Task TestGet()
        {
            var categories = await _categoriesRepository.Get();

            Assert.AreEqual(4, categories.Count());
        }

        [TestMethod]
        public async Task TestGetById()
        {
            var category = await _categoriesRepository.Get(4);

            Assert.AreEqual("Category4", category.Name);
        }

        [TestMethod]
        public async Task TestCreate()
        {
            Assert.IsTrue(await _categoriesRepository.Create(new Category {Name = "Category5"}));

            var categories = await _categoriesRepository.Get();

            Assert.AreEqual(5, categories.Count());
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Assert.IsTrue(await _categoriesRepository.Update(new Category {Id = 1, Name = "First Category"}));

            var category = await _categoriesRepository.Get(1);

            Assert.AreEqual("First Category", category.Name);
        }

        [TestMethod]
        public async Task TestDelete()
        {
            Assert.IsTrue(await _categoriesRepository.Delete(4));

            var categories = await _categoriesRepository.Get();

            Assert.AreEqual(3, categories.Count());
        }

        [TestMethod]
        public async Task TestGetRoot()
        {
            var categories = await _categoriesRepository.GetRoot();

            Assert.AreEqual(2, categories.Count());
        }

        [TestMethod]
        public async Task TestGetChildren()
        {
            var categories = await _categoriesRepository.GetChildren(1);

            Assert.AreEqual(1, categories.Count());
        }
    }
}