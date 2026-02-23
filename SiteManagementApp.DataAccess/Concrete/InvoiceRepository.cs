using Microsoft.EntityFrameworkCore;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;
using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(SiteManagementDbContext context) : base(context)
        {
        }

        public async Task<List<Invoice>> GetByApartmentIdAsync(int apartmentId)
        {
            return await _context.Invoices
                .Where(i => i.ApartmentId == apartmentId)
                .ToListAsync();
        }

        public async Task<List<Invoice>> GetUnpaidAsync()
        {
            return await _context.Invoices
                .Where(i => i.Status != PaymentStatus.Paid)
                .ToListAsync();
        }
    }
}
