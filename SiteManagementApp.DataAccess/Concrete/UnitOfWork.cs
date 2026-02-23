using SiteManagementApp.DataAccess.Abstract;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteManagementDbContext _context;

        public UnitOfWork(SiteManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
