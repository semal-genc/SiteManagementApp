using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Abstract
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task<List<Payment>> GetByInvoiceIdAsync(int invoiceId);
        Task MakePaymentAsync(int invoiceId, decimal amount);
        Task DeleteAsync(int id);
    }
}
