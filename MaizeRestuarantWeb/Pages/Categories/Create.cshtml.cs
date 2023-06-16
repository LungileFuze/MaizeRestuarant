using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;
        public Category Category { get; set; }
        public CreateModel(MaizeRestuarantDbContext maizeContext)
        {
            _context = maizeContext;
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
                await _context.AddAsync(Category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category added successfully";
                return RedirectToPage("Index");
            }
            return Page();
         
        }
    }
}
