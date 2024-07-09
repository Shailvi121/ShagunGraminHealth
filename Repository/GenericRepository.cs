using Microsoft.EntityFrameworkCore;
using ShagunGraminHealth.Data;
using ShagunGraminHealth.Interface;
using System.Linq.Expressions;

namespace ShagunGraminHealth.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ShagunGraminHealthContext context { get; set; }
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ShagunGraminHealthContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }


        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
