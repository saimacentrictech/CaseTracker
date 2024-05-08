using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.DataAccessLayerInfrastructure.Repository;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    
    public class Unitofwork:IUnitofwork
    {

        private readonly ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        


        public Unitofwork(ApplicationDbContext context) 
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductsRepository(context);
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
