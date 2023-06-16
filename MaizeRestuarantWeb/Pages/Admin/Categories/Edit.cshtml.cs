using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;
        public Category Category { get; set; }
        public EditModel(MaizeRestuarantDbContext maizeContext)
        {
            _context = maizeContext;
        }
        
        public void OnGet(int id)
        {
            Category = _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _context.Update(Category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
         
        }
    }
}
