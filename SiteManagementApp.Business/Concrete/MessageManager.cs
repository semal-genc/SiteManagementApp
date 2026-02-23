using SiteManagementApp.Business.Abstract;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageManager(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(int id)
        {
            var message = _messageRepository.GetByIdAsync(id).Result;

            if (message is null)
                throw new KeyNotFoundException("Message not found");
            await _messageRepository.DeleteAsync(message);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _messageRepository.GetAllAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);

            if (message is null)
                throw new KeyNotFoundException("Message not found");
            return message;
        }

        public async Task<List<Message>> GetInboxAsync(int userId)
        {
            return await _messageRepository.GetInboxAsync(userId);
        }

        public async Task<List<Message>> GetSentMessagesAsync(int userId)
        {
            return await _messageRepository.GetSentMessagesAsync(userId);
        }

        public Task SendMessageAsync(int senderId, int receiverId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new KeyNotFoundException("Message content cannot be empty");

            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                SentDate = DateTime.UtcNow
            };

            return _messageRepository.AddAsync(message);
        }
    }
}
