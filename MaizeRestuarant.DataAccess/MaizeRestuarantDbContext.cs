
using MaizeRestuarant.Models;
using Microsoft.EntityFrameworkCore;


namespace MaizeRestuarantWeb.Model
{
    public class MaizeRestuarantDbContext : DbContext
    {
        public MaizeRestuarantDbContext(DbContextOptions<MaizeRestuarantDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
