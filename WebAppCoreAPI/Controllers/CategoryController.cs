using DataAccess.DAO;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        [HttpPost("GetCategories")]
        public List<Category> GetCategories()
        {
            return _category.GetCategories();
        }
    }
}
