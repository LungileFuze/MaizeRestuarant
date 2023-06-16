using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;
        public FoodType FoodType { get; set; }
        public DeleteModel(MaizeRestuarantDbContext maizeContext)
        {
            _context = maizeContext;
        }

        public void OnGet(int id)
        {
            FoodType = _context.FoodType.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
                _context.Remove(FoodType);
                await _context.SaveChangesAsync();
                TempData["success"] = "Food type deleted successfully";
                return RedirectToPage("Index");
            }
        }
    }

