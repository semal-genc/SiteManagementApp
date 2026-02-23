using Microsoft.AspNetCore.Identity;
using SiteManagementApp.Entities.Enums;

namespace SiteManagementApp.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public string TCNo { get; set; } = null!;
        public string? PlateNumber { get; set; }

        public ResidentType? ResidentType { get; set; }

        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new HashSet<Message>();
    }
}
