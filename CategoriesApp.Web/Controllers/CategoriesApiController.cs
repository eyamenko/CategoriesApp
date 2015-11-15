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

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetRoot()
        {
            return Ok(await _categoriesService.GetRoot());
        }

        [HttpGet]
        [Route("{id}/children")]
        public async Task<IHttpActionResult> GetChildren(int id)
        {
            return Ok(await _categoriesService.GetChildren(id));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _categoriesService.Get(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(Category category)
        {
            if (await _categoriesService.Create(category))
                return Ok(new {success = true});
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, Category category)
        {
            if (await _categoriesService.Update(category))
                return Ok(new {success = true});
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (await _categoriesService.Delete(id))
                return Ok(new {success = true});
            return BadRequest();
        }
    }
}