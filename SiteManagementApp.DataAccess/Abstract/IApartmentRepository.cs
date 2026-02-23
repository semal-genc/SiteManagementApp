using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.DataAccess.Abstract
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
        Task<List<Apartment>> GetByBlockAsync(string blockName);
        Task<List<Apartment>> GetAvailableAsync();
    }
}
