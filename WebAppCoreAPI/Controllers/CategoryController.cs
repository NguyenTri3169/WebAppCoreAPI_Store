using DataAccess.DAO;
using DataAccess.DTO;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace WebAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _unitOfWork = null!;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetCategories")]
        public List<string> GetCategoryNames()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetCategories();
            List<Product> products = _unitOfWork.ProductRepository.GetProducts();

            List<string> names = categories.Select(c => c.Name).ToList();
            List<string> productNames = products.Select(p => p.Name).ToList();

            names.AddRange(productNames);

            return names;
        }

        [HttpGet("CreateCategories")]
        public int CreateCategories(Category category)
        {
            _unitOfWork.CategoryRepository.Create(category);
            return _unitOfWork.SaveChange();
        }
    }
}
