using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.DataAccess.Abstract
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<List<Invoice>> GetByApartmentIdAsync(int apartmentId);
        Task<List<Invoice>> GetUnpaidAsync();
    }
}
