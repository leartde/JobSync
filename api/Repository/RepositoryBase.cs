using System.Linq.Expressions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private  RepositoryContext _context;
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>()
                .AsNoTracking();
        }
        
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task CreateBulk(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }
        
        public void DeleteBulk(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }