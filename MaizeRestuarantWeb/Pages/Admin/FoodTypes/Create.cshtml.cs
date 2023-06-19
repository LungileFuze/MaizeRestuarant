using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;

        public FoodType FoodType { get; set; }

        public CreateModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        { 
            if(ModelState.IsValid) 
            { 
                _unityOfWork.FoodType.Add(FoodType);
                _unityOfWork.Save();
                TempData["success"] = "Food type added successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
