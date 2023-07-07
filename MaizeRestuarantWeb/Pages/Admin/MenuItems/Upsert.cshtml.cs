using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        public void OnGet(int? id)
        {
            if(id != null)
            {
                MenuItem = _unityOfWork.MenuItem.GetFirstorDefault(m => m.Id == id);    
            }

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
                //Update
                var objFromDb = _unityOfWork.MenuItem.GetFirstorDefault(m => m.Id == MenuItem.Id);
                if(files.Count != 0) 
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\menuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete old image
                    var oldImage = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\')); 
                    if(System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    MenuItem.Image = @"\images\menuItems\" + fileName_new + extension;
                }
                else
                {
                    MenuItem.Image = objFromDb.Image;
                }
                _unityOfWork.MenuItem.Update(MenuItem);
                _unityOfWork.Save();
            }
            return RedirectToPage("./Index");
        }
    }
}
