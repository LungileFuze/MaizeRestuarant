using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;

        public FoodType FoodType { get; set; }

        public EditModel(MaizeRestuarantDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            FoodType = _context.FoodType.FirstOrDefault(f => f.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid) 
            {
                _context.Update(FoodType);
                await _context.SaveChangesAsync();
                TempData["success"] = "Food type updated successfully";
                return RedirectToAction("Index");
            }
            return Page();
        }
    }
}
