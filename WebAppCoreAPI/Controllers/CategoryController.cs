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
        //private readonly ICategory _category;
        private IUnitOfWork _unitOfWork = null!;   
        public CategoryController(/*ICategory category*/ IUnitOfWork unitOfWork)
        {
            //_category = category;
            _unitOfWork = unitOfWork;   
        }
        [HttpPost("GetCategories")]
        public List<Category> GetCategories()
        {

            //return _category.GetCategories();
            return _unitOfWork._category.GetCategories();
        }
        [HttpGet("CreateCategories")]
        public int CreateCategories(Category category)
        {
            //return _category.Create(category);
            _unitOfWork._category.Create(category);
            return _unitOfWork.SaveChange();
        }   
    }
}
