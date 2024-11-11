using Microsoft.AspNetCore.Mvc;
using Razor.DataAccess.Repository.IRepository;

namespace RazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWOrk;
        public MenuItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menuItemList = _unitOfWOrk.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new {data = menuItemList});
        }
    }
}
