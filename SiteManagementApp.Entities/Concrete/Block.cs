namespace SiteManagementApp.Entities.Concrete
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
