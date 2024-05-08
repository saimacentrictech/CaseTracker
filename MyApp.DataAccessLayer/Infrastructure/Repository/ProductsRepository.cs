

using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.DataAccessLayer.Infrastructure.Repository;
using MyApp.Models;

namespace MyApp.DataAccessLayerInfrastructure.Repository
{
    public class ProductsRepository : Repository<Products>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Products products)
        {
            var productsdb = _context.products.FirstOrDefault(x=> x.Id == products.Id);
            if (productsdb != null) 
            {
                productsdb.Name = products.Name;
                productsdb.Description = products.Description;

                if (products.ImageUrl!=null)
                {
                    productsdb.ImageUrl = products.ImageUrl;
                }
            }
        }
    }
}
