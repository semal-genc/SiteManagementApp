using SiteManagementApp.Business.Abstract;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IGenericRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(User user)
        {
            await _repository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is not null)           
                await _repository.DeleteAsync(user);
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            await _repository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
