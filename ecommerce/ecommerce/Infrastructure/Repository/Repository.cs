using ecommerce.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using webapp.Model.Models;

namespace ecommerce.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
                _context = context;
                 _dbSet = _context.Set<T>();    
        }
        public void Added(T entity)
        {
           _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
           _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
          return _dbSet.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}
