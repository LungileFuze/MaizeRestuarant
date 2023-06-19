using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaizeRestuarantWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork; 

        public IndexModel(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork; 
        }

        public IEnumerable<FoodType> FoodTypes { get; set; }    
        public void OnGet()
        {
            FoodTypes = _unityOfWork.FoodType.GetAll(); 
        }
    }
}
