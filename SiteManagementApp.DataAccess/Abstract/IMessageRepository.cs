using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.DataAccess.Abstract
{
    public interface IMessageRepository:IGenericRepository<Message>
    {
        Task<List<Message>> GetInboxAsync(int userId);
        Task<List<Message>> GetSentMessagesAsync(int userId);
    }
}
