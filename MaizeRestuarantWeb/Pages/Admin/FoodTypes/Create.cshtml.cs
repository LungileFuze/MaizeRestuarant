using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;

        public FoodType FoodType { get; set; }

        public CreateModel(MaizeRestuarantDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        { 
            if(ModelState.IsValid) 
            { 
                await _context.AddAsync(FoodType);
                await _context.SaveChangesAsync();
                TempData["success"] = "Food type added successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
