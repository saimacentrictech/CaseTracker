using ecommerce.Infrastructure.IRepository;
using webapp.Model.Models;

namespace ecommerce.Infrastructure.Repository
{
    
    public class Unitofwork:IUnitofwork
    {

        private readonly AppDbContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository productRepository { get; private set; }


        public Unitofwork(AppDbContext context) 
        {
            _context = context;
            CategoryRepository = new CategoryRepository(context);
            productRepository = new ProductRespository(context);
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
