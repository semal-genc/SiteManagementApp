using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Abstract
{
    public interface IApartmentService
    {
        Task<List<Apartment>> GetAllAsync();
        Task<Apartment> GetByIdAsync(int id);
        Task<List<Apartment>> GetByBlockAsync(string blockName);
        Task<List<Apartment>> GetAvailableAsync();
        Task AddAsync(Apartment apartment);
        Task UpdateAsync(Apartment apartment);
        Task DeleteAsync(int id);
    }
}
