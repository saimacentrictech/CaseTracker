using ecommerce.Infrastructure.IRepository;
using webapp.Model;
using webapp.Model.Models;

namespace ecommerce.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categorydb = _context.categories.FirstOrDefault(x=> x.Id == category.Id);
            if (categorydb != null) 
            {
               categorydb.Name = category.Name; 
                categorydb.DisplayOrder = category.DisplayOrder;    
            }
        }
    }
}
