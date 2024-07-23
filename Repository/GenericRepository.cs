using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using ShagunGraminHealth.Data;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShagunGraminHealth.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShagunGraminHealthContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ShagunGraminHealthContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(predicate);
            }
            catch (Exception)
            {

                throw;
            }
       
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        //public async Task<T> GetByOrderIdAsync(string OrderId)
        //{
        //    return await _dbSet.FindAsync(OrderId);
        //}

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
       public async Task<List<string>> GetRolesByUserIdAsync(int userId)
        {
            try
            {
                var roles = await _context.UserRoles
                    .Where(ur => ur.UserId == userId)
                    .Select(ur => ur.Role.Name)
                    .ToListAsync();

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user roles.", ex);
            }
        }

        public async Task<List<T>> GetByOrderIdAsync(string orderId)
        {
            return await _dbSet.Where(Orders => EF.Property<string>(Orders, "OrderId") == orderId).ToListAsync();
        }


    }
}
