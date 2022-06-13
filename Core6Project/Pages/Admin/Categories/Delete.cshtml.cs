using Food.DataAccess.Data;
using Food.DataAccess.IRepository;
using Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core6Project.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Categories { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Categories = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == Categories.Id);
            if (categoryFromDb != null)
            {
                _unitOfWork.Category.Remove(categoryFromDb);
                _unitOfWork.Save();
                TempData["Success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }


            return Page();
        }
    }
}
