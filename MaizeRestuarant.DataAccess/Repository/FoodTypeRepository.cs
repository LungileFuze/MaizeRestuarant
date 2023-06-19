using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using MaizeRestuarant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaizeRestuarant.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly MaizeRestuarantDbContext _context; 
        public FoodTypeRepository(MaizeRestuarantDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(FoodType foodType)
        {
            var typeFromDb = _context.FoodType.FirstOrDefault(f => f.Id == foodType.Id);
            typeFromDb.Name = foodType.Name;    
        }
    }
}
