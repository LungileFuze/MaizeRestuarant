using MaizeRestuarant.Models;
using Microsoft.EntityFrameworkCore;


namespace MaizeRestuarant.DataAccess.Data
{
    public class MaizeRestuarantDbContext : DbContext
    {
        public MaizeRestuarantDbContext(DbContextOptions<MaizeRestuarantDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<FoodType> FoodType{ get; set; }
    }
}
