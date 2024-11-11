using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.DataAccess;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;


namespace RazorApp.Admin.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Category> categories { get; set; }

        public IndexModel(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        public void OnGet()
        {
            categories = _unitOfWork.Category.GetAll();

        }
    }
}
