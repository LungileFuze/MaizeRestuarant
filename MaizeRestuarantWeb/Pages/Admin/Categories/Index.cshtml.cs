using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;

        public IndexModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public IEnumerable<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _unityOfWork.Category.GetAll();
        }
    }
}
