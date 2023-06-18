using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;
        public Category Category { get; set; }
        public CreateModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {
                _unityOfWork.Category.Add(Category);
                _unityOfWork.Save();
                TempData["success"] = "Category added successfully";
                return RedirectToPage("Index");
            }
            return Page();
         
        }
    }
}
