using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _contextCategory;

        public IndexModel(ICategoryRepository contextCategory)
        {
            _contextCategory = contextCategory;
        }

        public IEnumerable<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _contextCategory.GetAll();
        }
    }
}
