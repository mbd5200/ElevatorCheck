using ElevatorCheckAPI.DAL.Abstract.DataManagement;
using ElevatorCheckAPI.Entity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfRepository<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(DbContext context)/* Constructor Injection */
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<EntityEntry<T>> AddAsync(T Entity)
        {
            return await _dbSet.AddAsync(Entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;/*select * from user */

           
            if (Filter != null)
            {
                query = query.Where(Filter);/*select * from User Where id >5 */
            }
            if (IncludeProperties.Length > 0)
            {
                foreach (string includeProperty in IncludeProperties) // User,Maintenance, Fault....
                {
                    query = query.Include(includeProperty);
                }
            }
            return await Task.Run(() => query);

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (IncludeProperties.Length > 0)
            {
                foreach (string includeProperty in IncludeProperties) // User,Maintenance, Fault....
                {
                    query = query.Include(includeProperty);
                }
            }

            /* select * from User where phone=5304956051 */

            return await query.SingleOrDefaultAsync(Filter);
        }

        public async Task RemoveAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Remove(Entity));
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Update(Entity));
        }
    }
}
