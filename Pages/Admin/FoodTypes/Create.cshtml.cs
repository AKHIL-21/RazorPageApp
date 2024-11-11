using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;

namespace RazorApp.Pages.Admin.FoodTypes
{
   
    public class CreateModel : PageModel
    {
        [BindProperty]
        public FoodType FoodType { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
           
            if (ModelState.IsValid)
            {
                 _unitOfWork.FoodType.Add(FoodType);
                 _unitOfWork.Save();
                TempData["success"] = "FoodType Created SuccesfullY !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
