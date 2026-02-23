using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(int id);
        Task<List<Invoice>> GetByApartmentIdAsync(int apartmentId);
        Task<List<Invoice>> GetUnpaidAsync();
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(int id);
    }
}
