using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaizeRestuarantWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;

        public MenuItem MenuItem { get; set; }  

        public IEnumerable<SelectListItem>CategoryList { get; set; }

        public IEnumerable<SelectListItem>FoodTypeList { get; set; }

        public UpsertModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            MenuItem = new();
        }
        public void OnGet()
        {
            CategoryList = _unityOfWork.Category.GetAll().Select(c => new SelectListItem 
            { 
                Text = c.Name,
                Value = c.Id.ToString(),
            });

            FoodTypeList = _unityOfWork.FoodType.GetAll().Select(f => new SelectListItem
            {
                Text = f.Name,
                Value = f.Id.ToString(),    
            });
        }

        public async Task<IActionResult> OnPost() 
        {
            return Page();
        }
    }
}
