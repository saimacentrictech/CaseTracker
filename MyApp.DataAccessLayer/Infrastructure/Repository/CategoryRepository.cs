

using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.DataAccessLayer.Infrastructure.Repository;
using MyApp.Models;

namespace MyApp.DataAccessLayerInfrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categorydb = _context.Categories.FirstOrDefault(x=> x.Id == category.Id);
            if (categorydb != null) 
            {
               categorydb.Name = category.Name; 
                categorydb.DisplayOrder = category.DisplayOrder;    
            }
        }
    }
}
