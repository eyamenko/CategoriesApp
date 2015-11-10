namespace CategoriesApp.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Contracts.Services;
    using Models;

    [RoutePrefix("api/categories")]
    public class CategoriesApiController : ApiController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesApiController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetRoot()
        {
            return Ok(await _categoriesService.GetRoot());
        }

        [Route("{id}/children")]
        public async Task<IHttpActionResult> GetChildren(int id)
        {
            return Ok(await _categoriesService.GetChildren(id));
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _categoriesService.Get(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(Category category)
        {
            return Ok(new {success = await _categoriesService.Create(category)});
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, Category category)
        {
            return Ok(new {success = await _categoriesService.Update(category)});
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Ok(new {success = await _categoriesService.Delete(id)});
        }
    }
}