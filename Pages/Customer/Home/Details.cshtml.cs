using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.DataAccess.Repository.IRepository;
using Razor.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorApp.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Range(1,100,ErrorMessage ="please select a count between 1 and 100")]
        public int Count { get; set; }
        public MenuItem MenuItem { get; set; }
        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id,includeProperties:"Category,FoodType");
        }
    }
}
