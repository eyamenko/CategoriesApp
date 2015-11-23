namespace CategoriesApp.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CategoriesApp.Services;
    using Contracts.Data;
    using Contracts.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;

    [TestClass]
    public class CategoriesServiceTests
    {
        private ICategoriesService _categoriesService;

        [TestInitialize]
        public void Initialize()
        {
            var categoriesRepository = new Mock<ICategoriesRepository>();
            var categories = new List<Category>
            {
                new Category {Id = 1, Name = "Category1"},
                new Category {Id = 2, Name = "Category2", ParentId = 1},
                new Category {Id = 3, Name = "Category3", ParentId = 2},
                new Category {Id = 4, Name = "Category4", ParentId = 1},
                new Category {Id = 5, Name = "Category5"}
            };

            categoriesRepository.Setup(r => r.Get()).ReturnsAsync(categories);
            categoriesRepository.Setup(r => r.Get(It.IsAny<int>())).Returns((int id) => Task.FromResult(categories.FirstOrDefault(c => c.Id == id)));
            categoriesRepository.Setup(r => r.Create(It.IsAny<Category>())).ReturnsAsync(true);
            categoriesRepository.Setup(r => r.Update(It.IsAny<Category>())).ReturnsAsync(true);
            categoriesRepository.Setup(r => r.GetChildren(It.IsAny<int>())).Returns(
                (int id) => Task.FromResult(categories.Where(c => c.ParentId == id).ToList() as IEnumerable<Category>));
            categoriesRepository.Setup(r => r.GetRoot()).ReturnsAsync(categories.Where(c => c.ParentId == null).ToList());
            categoriesRepository.Setup(r => r.Delete(It.IsAny<int>())).Returns((int id) => Task.FromResult(categories.RemoveAll(c => c.Id == id) > 0));

            _categoriesService = new CategoriesService(categoriesRepository.Object);
        }

        [TestMethod]
        public async Task TestGet()
        {
            var categories = await _categoriesService.Get();

            Assert.AreEqual(5, categories.Count());
        }

        [TestMethod]
        public async Task TestGetById()
        {
            var category = await _categoriesService.Get(5);

            Assert.AreEqual(5, category.Id);
        }

        [TestMethod]
        public async Task TestCreate()
        {
            Assert.IsTrue(await _categoriesService.Create(new Category {Id = 1, Name = "Category1"}));
            Assert.IsFalse(await _categoriesService.Create(new Category {Id = 2}));
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Assert.IsTrue(await _categoriesService.Update(new Category {Id = 1, Name = "Category1"}));
            Assert.IsFalse(await _categoriesService.Update(new Category {Id = 2}));
        }

        [TestMethod]
        public async Task TestGetChildren()
        {
            var children = await _categoriesService.GetChildren(1);

            Assert.AreEqual(2, children.Count());
        }

        [TestMethod]
        public async Task TestGetRoot()
        {
            var categories = await _categoriesService.GetRoot();

            Assert.AreEqual(2, categories.Count());
        }

        [TestMethod]
        public async Task TestDelete()
        {
            var categories = await _categoriesService.Get();

            Assert.IsTrue(await _categoriesService.Delete(1));
            Assert.AreEqual(1, categories.Count());
        }
    }
}