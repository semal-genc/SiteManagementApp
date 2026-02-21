using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string TCNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? PlateNumber { get; set; }

        public UserRole Role { get; set; }
        public string PasswordHash { get; set; }

        public int? ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
