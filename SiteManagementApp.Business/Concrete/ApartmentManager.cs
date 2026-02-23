using SiteManagementApp.Business.Abstract;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentManager(IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork)
        {
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Apartment apartment)
        {
            await _apartmentRepository.AddAsync(apartment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(id);

            if (apartment is null)
                throw new KeyNotFoundException("Apartment not found.");

            await _apartmentRepository.DeleteAsync(apartment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Apartment>> GetAllAsync()
        {
            return await _apartmentRepository.GetAllAsync();
        }

        public async Task<List<Apartment>> GetAvailableAsync()
        {
            return await _apartmentRepository.GetAvailableAsync();
        }

        public async Task<List<Apartment>> GetByBlockAsync(string blockName)
        {
            return await _apartmentRepository.GetByBlockAsync(blockName);
        }

        public async Task<Apartment> GetByIdAsync(int id)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(id);

            if (apartment is null)
                throw new KeyNotFoundException("Apartment not found.");
            return apartment;
        }

        public async Task UpdateAsync(Apartment apartment)
        {
            await _apartmentRepository.UpdateAsync(apartment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
