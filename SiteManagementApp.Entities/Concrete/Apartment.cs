using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Entities.Concrete
{
    public class Apartment
    {
        public int Id { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; } = null!;
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public string Type { get; set; } = null!;

        public ApartmentStatus Status { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
