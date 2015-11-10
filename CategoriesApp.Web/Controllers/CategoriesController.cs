namespace CategoriesApp.Web.Controllers
{
    using System.Web.Mvc;
    using Models.ViewModels;

    public class CategoriesController : Controller
    {
        public ActionResult All()
        {
            return View(new BaseViewModel {Title = "Categories"});
        }
    }
}