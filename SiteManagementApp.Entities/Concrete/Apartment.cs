using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Entities.Concrete
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Block { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public string Type { get; set; }

        public ApartmentStatus Status { get; set; }
        public ResidentType ResidentType { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
