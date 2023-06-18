using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaizeRestuarant.DataAccess.Repository.IRepository
{
    public interface IUnityOfWork : IDisposable
    {
        ICategoryRepository Category{ get; }

        void Save();
    }
}
