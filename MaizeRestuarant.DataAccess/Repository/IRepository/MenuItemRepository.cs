using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.Models;


namespace MaizeRestuarant.DataAccess.Repository.IRepository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly MaizeRestuarantDbContext _context; 
        public MenuItemRepository(MaizeRestuarantDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(MenuItem menuItem)
        {
            var objFromDb = _context.MenuItem.FirstOrDefault(m => m.Id == menuItem.Id);
            objFromDb.Name = menuItem.Name;
            objFromDb.Description = menuItem.Description;  
            objFromDb.Price = menuItem.Price;
            objFromDb.FoodTypeId = menuItem.FoodTypeId;
            objFromDb.CategoryId = menuItem.CategoryId;
            if (objFromDb.Image != null)
            {
                objFromDb.Image = menuItem.Image;
            }
        }
    }
}
