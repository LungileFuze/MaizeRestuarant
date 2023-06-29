using MaizeRestuarant.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MaizeRestuarantWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnityOfWork _unityOfWork; 

        public MenuItemController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menuItemList = _unityOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new {data= menuItemList});
        }
    }
}
