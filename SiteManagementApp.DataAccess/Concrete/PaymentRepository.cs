using Microsoft.EntityFrameworkCore;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(SiteManagementDbContext context) : base(context)
        {
        }

        public async Task<List<Payment>> GetByInvoiceIdAsync(int invoiceId)
        {
            return await _context.Payments
                .Where(p => p.InvoiceId == invoiceId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPaidForInvoiceAsync(int invoiceId)
        {
            return await _context.Payments
                .Where(p => p.InvoiceId == invoiceId)
                .SumAsync(p => p.Amount);
        }
    }
}
