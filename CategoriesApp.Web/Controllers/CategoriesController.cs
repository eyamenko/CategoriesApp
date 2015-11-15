namespace CategoriesApp.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Contracts.Services;
    using Models.ViewModels;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public ActionResult All()
        {
            return View(new BaseViewModel {Title = "Categories"});
        }

        public ActionResult New()
        {
            return View(new BaseViewModel {Title = "New Category"});
        }

        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoriesService.Get(id);

            if (category == null)
                return HttpNotFound();

            return View(new CategoriesEditViewModel {Title = "Edit Category", Category = category});
        }
    }
}