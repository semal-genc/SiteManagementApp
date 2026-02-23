using Microsoft.EntityFrameworkCore;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(SiteManagementDbContext context) : base(context)
        {
        }

        public async Task<List<Message>> GetInboxAsync(int userId)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Where(m => m.ReceiverId == userId)
                .OrderByDescending(m => m.SentDate)
                .ToListAsync();
        }

        public async Task<List<Message>> GetSentMessagesAsync(int userId)
        {
            return await _context.Messages
                .Include(m => m.Receiver)
                .Where(m => m.SenderId == userId)
                .OrderByDescending(m => m.SentDate)
                .ToListAsync();
        }
    }
}
