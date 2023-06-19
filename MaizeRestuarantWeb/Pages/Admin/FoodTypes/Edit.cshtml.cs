using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;

        public FoodType FoodType { get; set; }

        public EditModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unityOfWork.FoodType.GetFirstorDefault(f => f.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid) 
            {
                _unityOfWork.FoodType.Update(FoodType);
                _unityOfWork.Save();
                TempData["success"] = "Food type updated successfully";
                return RedirectToAction("Index");
            }
            return Page();
        }
    }
}
