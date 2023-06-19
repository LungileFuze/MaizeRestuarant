

namespace MaizeRestuarant.DataAccess.Repository.IRepository
{
    public interface IUnityOfWork : IDisposable
    {
        ICategoryRepository Category{ get; }

        IFoodTypeRepository FoodType { get; }

        IMenuItemRepository MenuItem { get; }

        void Save();
    }
}
