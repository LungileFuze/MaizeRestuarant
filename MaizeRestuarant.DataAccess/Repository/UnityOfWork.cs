using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;


namespace MaizeRestuarant.DataAccess.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly MaizeRestuarantDbContext _context;     
        public UnityOfWork(MaizeRestuarantDbContext dbContext) 
        { 
            _context = dbContext;
            Category = new CategoryRepository(dbContext);
            FoodType = new FoodTypeRepository(dbContext);  
            MenuItem = new MenuItemRepository(dbContext);
        }
        public ICategoryRepository Category { get; private set; }

        public IFoodTypeRepository FoodType { get; private set; }   

        public IMenuItemRepository MenuItem { get; private set; }   

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
