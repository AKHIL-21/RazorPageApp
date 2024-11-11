using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;


namespace RazorApp.Pages.Admin.FoodTypes
{
   
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public FoodType FoodType { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id ==id);
        }

        public async Task<IActionResult> OnPost()
        {
            
          
            
                var foodTypefromDB = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
            if (foodTypefromDB != null)
                {
                    _unitOfWork.FoodType.Remove(foodTypefromDB);
                _unitOfWork.Save();
                TempData["success"] = "Category Deleted SuccesfullY !";
                return RedirectToPage("Index");
                }



            return Page();  
            
        }
    }
}
