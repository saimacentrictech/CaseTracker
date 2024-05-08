using webapp.Model;

namespace ecommerce.Infrastructure.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void Update(Category category);


    }
}
