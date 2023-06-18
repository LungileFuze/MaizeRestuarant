using MaizeRestuarant.DataAccess.Data;
using MaizeRestuarant.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaizeRestuarant.DataAccess.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly MaizeRestuarantDbContext _context;     
        public UnityOfWork(MaizeRestuarantDbContext dbContext) 
        { 
            _context = dbContext;
            Category = new CategoryRepository(dbContext);
        }
        public ICategoryRepository Category { get; private set; }

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
