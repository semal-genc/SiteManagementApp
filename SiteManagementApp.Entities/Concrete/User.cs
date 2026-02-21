using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;
        public string TCNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PlateNumber { get; set; }

        public UserRole Role { get; set; }
        public ResidentType? ResidentType { get; set; }
        public string PasswordHash { get; set; } = null!;

        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new HashSet<Message>();
    }
}
