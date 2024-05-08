namespace ecommerce.Infrastructure.IRepository
{
    public interface IUnitofwork
    {
        // common functions k lye repository bnaty 
        ICategoryRepository CategoryRepository { get; }
        IProductRepository productRepository { get; }

        void save();
    }
}
