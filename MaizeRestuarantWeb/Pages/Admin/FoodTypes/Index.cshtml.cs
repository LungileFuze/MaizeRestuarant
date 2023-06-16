using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context; 

        public IndexModel(MaizeRestuarantDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<FoodType> FoodTypes { get; set; }    
        public void OnGet()
        {
            FoodTypes = _context.FoodType; 
        }
    }
}
