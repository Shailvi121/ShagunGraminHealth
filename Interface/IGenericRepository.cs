using System.Linq.Expressions;

namespace ShagunGraminHealth.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
        Task<List<string>> GetRolesByUserIdAsync(int userId);
        Task<List<T>> GetByOrderIdAsync(string orderId);
        

    }
}
