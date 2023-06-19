using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;
        public FoodType FoodType { get; set; }
        public DeleteModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unityOfWork.FoodType.GetFirstorDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDB = _unityOfWork.FoodType.GetFirstorDefault(f => f.Id == FoodType.Id);
            if (categoryFromDB != null)
            {
                _unityOfWork.FoodType.Remove(categoryFromDB);
                _unityOfWork.Save();
                TempData["success"] = "Food type deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
        }
    }

