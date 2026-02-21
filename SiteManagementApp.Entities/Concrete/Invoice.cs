using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Entities.Concrete
{
    public class Invoice
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public InvoiceType Type { get; set; }
        public decimal Amount { get; set; }

        public bool IsPaid { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
