using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.WebRequestMethods;

namespace MaizeRestuarantWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IWebHostEnvironment _webEnvironment;

        public MenuItem MenuItem { get; set; }  

        public IEnumerable<SelectListItem>CategoryList { get; set; }

        public IEnumerable<SelectListItem>FoodTypeList { get; set; }

        public UpsertModel(IUnityOfWork unityOfWork, IWebHostEnvironment webEnvironment)
        {
            _unityOfWork = unityOfWork;
            _webEnvironment = webEnvironment;
            MenuItem = new(); 
        }
        public void OnGet()
        {
            CategoryList = _unityOfWork.Category.GetAll().Select(c => new SelectListItem 
            { 
                Text = c.Name,
                Value = c.Id.ToString(),
            });

            FoodTypeList = _unityOfWork.FoodType.GetAll().Select(f => new SelectListItem
            {
                Text = f.Name,
                Value = f.Id.ToString(),    
            });
        }
       
        public async Task<IActionResult> OnPost() 
        {
            string webRootPath = _webEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(MenuItem.Id == 0) 
            { 
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.Image = @"\images\menuItems\" + fileName_new + extension;
                _unityOfWork.MenuItem.Add(MenuItem);
                _unityOfWork.Save();
            }
            else
            {
                
            }
            return RedirectToPage("./Index");
        }
    }
}
