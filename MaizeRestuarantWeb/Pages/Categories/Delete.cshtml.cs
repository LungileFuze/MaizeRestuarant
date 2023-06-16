using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;
        public Category Category { get; set; }
        public DeleteModel(MaizeRestuarantDbContext maizeContext)
        {
            _context = maizeContext;
        }
        
        public void OnGet(int id)
        {
            Category = _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDB = _context.Categories.Find(Category.Id); 
            if (categoryFromDB != null) 
            {
                _context.Remove(categoryFromDB);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
