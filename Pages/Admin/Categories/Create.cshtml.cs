using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;

namespace RazorApp.Pages.Admin.Categories
{
   
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Category Categories { get; set; }
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
            if(Categories.Name == Categories.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Categories.Name", "The Display Order should not Match The Name.");
            }
            if (ModelState.IsValid)
            {
                 _unitOfWork.Category.Add(Categories);
                 _unitOfWork.Save();
                TempData["success"] = "Category Created SuccesfullY !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
