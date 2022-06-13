using Food.DataAccess.Data;
using Food.DataAccess.IRepository;
using Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core6Project.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(x=>x.Id==id);
            //Category = _db.Categories.First(u=>u.Id==id);
            //Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category = _db.Categories.Single(u => u.Id == id);
            //Category = _db.Categories.SingleOrDefault(u => u.Id == id);
            //Category = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) //3. bölüm 33. video
            {
                _unitOfWork.FoodType.Update(FoodType);
                _unitOfWork.Save();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
