using Microsoft.EntityFrameworkCore;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;
using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SiteManagementDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(SiteManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
