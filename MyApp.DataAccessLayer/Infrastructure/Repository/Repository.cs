
using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //this call  is generic  repository used 
        //    in entire project
        private readonly ApplicationDbContext _context;
        private  DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
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
