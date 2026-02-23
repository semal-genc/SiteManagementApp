using SiteManagementApp.Business.Abstract;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;
using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentManager(IPaymentRepository paymentRepository, IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);

            if (payment is null)
                throw new KeyNotFoundException("Payment not found");

            await _paymentRepository.DeleteAsync(payment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);

            if (payment is null)
                throw new KeyNotFoundException("Payment not found");
            return payment;
        }

        public async Task<List<Payment>> GetByInvoiceIdAsync(int invoiceId)
        {
            return await _paymentRepository.GetByInvoiceIdAsync(invoiceId);
        }

        public async Task MakePaymentAsync(int invoiceId, decimal amount)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);

            if (invoice is null)
                throw new KeyNotFoundException("Invoice not found");

            if (invoice.Status == PaymentStatus.Paid)
                throw new InvalidOperationException("Invoice is already paid");

            if (amount < 0)
                throw new InvalidOperationException("Amount must be greater than zero");

            var payment = new Payment
            {
                InvoiceId = invoiceId,
                Amount = amount,
                PaymentDate = DateTime.UtcNow
            };

            await _paymentRepository.AddAsync(payment);

            invoice.Status = PaymentStatus.Paid;

            await _invoiceRepository.UpdateAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
