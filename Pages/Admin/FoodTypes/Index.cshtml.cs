using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;


namespace RazorApp.Admin.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            FoodTypes = _unitOfWork.FoodType.GetAll();

        }
    }
}
