
namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitofwork
    {
        // common functions k lye repository bnaty 
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        void save();
    }
}
