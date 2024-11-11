using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;

namespace RazorApp.Pages.Admin.Categories
{
   
    public class EditModel : PageModel
    {
        
        private readonly IUnitOfWork _unitOfWork;


        [BindProperty]
        public Category Categories { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Categories = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(Categories.Name == Categories.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Categories.Name", "The Display Order should not Match The Name.");
            }
            if (ModelState.IsValid)
            {
                 _unitOfWork.Category.Update(Categories);
                 _unitOfWork.Save();
                TempData["success"] = "Category update SuccesfullY !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
