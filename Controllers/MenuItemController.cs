using Microsoft.AspNetCore.Mvc;
using Razor.DataAccess.Repository.IRepository;

namespace RazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWOrk = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menuItemList = _unitOfWOrk.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new { data = menuItemList });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWOrk.MenuItem.GetFirstOrDefault(u => u.Id == id);

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWOrk.MenuItem.Remove(objFromDb);
            _unitOfWOrk.Save();
            
            return Json(new { success = true, message="Delete sucess." });
        }
    }
}
