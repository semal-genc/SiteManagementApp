using SiteManagementApp.Business.Abstract;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceManager(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _invoiceRepository.AddAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);

            if (invoice is null)
                throw new KeyNotFoundException("Invoice not found.");

            await _invoiceRepository.DeleteAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<List<Invoice>> GetByApartmentIdAsync(int apartmentId)
        {
            var invoices = await _invoiceRepository.GetByApartmentIdAsync(apartmentId);

            if (!invoices.Any())
                throw new KeyNotFoundException("No invoices found for the specified apartment.");

            return invoices;
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);

            if (invoice is null)
                throw new KeyNotFoundException("Invoice not found.");
            return invoice;
        }

        public async Task<List<Invoice>> GetUnpaidAsync()
        {
            return await _invoiceRepository.GetUnpaidAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            await _invoiceRepository.UpdateAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
