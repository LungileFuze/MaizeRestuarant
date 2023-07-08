using MaizeRestuarant.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MaizeRestuarantWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnityOfWork _unityOfWork; 
        private readonly IWebHostEnvironment _webHostEnvironment;   

        public MenuItemController(IUnityOfWork unityOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unityOfWork = unityOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menuItemList = _unityOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new {data= menuItemList});
        }
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        {
            var objFromDb = _unityOfWork.MenuItem.GetFirstorDefault(u => u.Id == id);
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
            if(System.IO.File.Exists(oldImagePath))
            { 
                System.IO.File.Delete(oldImagePath);
            }
            _unityOfWork.MenuItem.Remove(objFromDb);
            _unityOfWork.Save();
            return Json(new { success = true, message = "Delete successfully."});
        }
    }
}
