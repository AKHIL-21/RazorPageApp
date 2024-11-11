using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;


namespace RazorApp.Pages.Admin.Categories
{
   
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Categories { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public void OnGet(int id)
        {
            Categories = _unitOfWork.Category.GetFirstOrDefault(u =>u.Id==id);
        }

        public async Task<IActionResult> OnPost()
        {



            var categoryfromDB = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Categories.Id);
                if(categoryfromDB != null)
                {
                    _unitOfWork.Category.Remove(categoryfromDB);
                _unitOfWork.Save();
                TempData["success"] = "Category Deleted SuccesfullY !";
                return RedirectToPage("Index");
                }



            return Page();  
            
        }
    }
}
