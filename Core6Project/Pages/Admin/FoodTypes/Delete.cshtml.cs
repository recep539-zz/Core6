using Food.DataAccess.Data;
using Food.DataAccess.IRepository;
using Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core6Project.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {

            var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == FoodType.Id);
            if (foodTypeFromDb != null)
            {
                _unitOfWork.FoodType.Remove(foodTypeFromDb);
                _unitOfWork.Save();
                TempData["Success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }


            return Page();
        }
    }
}
