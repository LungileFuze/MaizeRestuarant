using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;
        public Category Category { get; set; }
        public EditModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void OnGet(int id)
        {
            Category = _unityOfWork.Category.GetFirstorDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _unityOfWork.Category.Update(Category);
                _unityOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
         
        }
    }
}
