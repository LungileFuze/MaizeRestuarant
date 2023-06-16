using MaizeRestuarant.Models;
using MaizeRestuarantWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly MaizeRestuarantDbContext _context;

        public IndexModel(MaizeRestuarantDbContext maizeDb)
        {
            _context = maizeDb;
        }

        public IEnumerable<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _context.Categories;
        }
    }
}
