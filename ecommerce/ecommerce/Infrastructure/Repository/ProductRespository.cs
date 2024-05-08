using ecommerce.Infrastructure.IRepository;
using MyApp.Models.Models;
using webapp.Model;
using webapp.Model.Models;

namespace ecommerce.Infrastructure.Repository
{
    public class ProductRespository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRespository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productdb = _context.products.FirstOrDefault(x => x.Id == product.Id);
            if (productdb != null) 
            {
              productdb.Name = product.Name;
                productdb.Description = product.Description;
                productdb.Price = product.Price;

                if (productdb.ImageUrl !=null )
                {
                productdb.ImageUrl = productdb.ImageUrl;    
                }

            }
            
        }
    }
}
