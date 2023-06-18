using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;
        public Category Category { get; set; }
        public DeleteModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void OnGet(int id)
        {
            Category = _unityOfWork.Category.GetFirstorDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDB = _unityOfWork.Category.GetFirstorDefault(c => c.Id == Category.Id); 
            if (categoryFromDB != null) 
            {
                _unityOfWork.Category.Remove(categoryFromDB);
                _unityOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
