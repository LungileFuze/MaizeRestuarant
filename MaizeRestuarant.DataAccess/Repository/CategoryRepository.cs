using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;


namespace MaizeRestuarant.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MaizeRestuarantDbContext _context;

        public CategoryRepository(MaizeRestuarantDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var objFromDb = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder; 
        }
    }
}
