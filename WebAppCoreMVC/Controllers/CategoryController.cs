using CommonLibs;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreMVC.Models;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        //CategoryRepository _CategoryRepository = null!;

        //public CategoryController(CategoryRepository categoryRepository)
        //{
        //    _CategoryRepository = categoryRepository;
        //}
        //public IActionResult Index()
        //{
        //    return View(_CategoryRepository.GetCategories());
        //}
        private readonly string _apiUrl = "http://localhost:36800"; // Địa chỉ của API
        private readonly string _endpoint = "/api/Category/GetCategories"; // Đường dẫn của API

        public async Task<IActionResult> Index(Category category)
        {
            // Chuyển đổi đối tượng Category thành chuỗi JSON
            string jsonData = JsonConvert.SerializeObject(category);

            // Gửi yêu cầu POST đến API để tạo một Category mới
            string response = await HttpHelper.SendPost(_apiUrl, _endpoint, jsonData);
            List<Category>? categories = JsonConvert.DeserializeObject<List<Category>>(response);
            // Xử lý phản hồi từ API (ví dụ: kiểm tra xem có lỗi hay không, v.v.)
            if (categories == null)
            {
                categories = new List<Category>(); // Nếu null, khởi tạo nó để tránh NullReferenceException
            }

            // Trả về View với danh sách các Category
            return View(categories);

        }
    }
}
