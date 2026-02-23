using SiteManagementApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteManagementApp.DataAccess.Abstract
{
    public interface IPaymentRepository: IGenericRepository<Payment>
    {
        Task<List<Payment>> GetByInvoiceIdAsync(int invoiceId);
        Task<decimal> GetTotalPaidForInvoiceAsync(int invoiceId);
    }
}
