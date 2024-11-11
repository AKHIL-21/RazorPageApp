using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;

namespace RazorApp.Pages.Admin.FoodTypes
{
   
    public class EditModel : PageModel
    {
        [BindProperty]
        public FoodType FoodType{ get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
           
            if (ModelState.IsValid)
            {
                 _unitOfWork.FoodType.Update(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType update SuccesfullY !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
