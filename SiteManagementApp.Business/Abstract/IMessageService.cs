using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Abstract
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllAsync();
        Task<Message> GetByIdAsync(int id);
        Task<List<Message>> GetInboxAsync(int userId);
        Task<List<Message>> GetSentMessagesAsync(int userId);
        Task SendMessageAsync(int senderId, int receiverId, string content);
        Task DeleteAsync(int id);
    }
}
