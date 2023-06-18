using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaizeRestuarant.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Get All, Get by Id First or Default, Add, Remove, RemoveRange
        void Add(T entity);
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
        IEnumerable<T> GetAll();
        T GetFirstorDefault(Expression<Func<T, bool>>? filter = null);
    }
}
