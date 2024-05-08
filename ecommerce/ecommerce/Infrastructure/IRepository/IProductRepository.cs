using MyApp.Models.Models;
using webapp.Model;

namespace ecommerce.Infrastructure.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);


    }
}
