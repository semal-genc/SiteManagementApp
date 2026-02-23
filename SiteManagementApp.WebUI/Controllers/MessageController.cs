using Microsoft.AspNetCore.Mvc;
using SiteManagementApp.Business.Abstract;

namespace SiteManagementApp.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Inbox(int userId)
        {
            var messages = await _messageService.GetInboxAsync(userId);
            return View(messages);
        }

        public async Task<IActionResult> Sent(int userId)
        {
            var messages = await _messageService.GetSentMessagesAsync(userId);
            return View(messages);
        }

        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(int senderId, int receiverId, string content)
        {
            try
            {
                await _messageService.SendMessageAsync(senderId, receiverId, content);
                return RedirectToAction("Sent", new { userId = senderId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _messageService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Inbox", new { userId = 1 });
        }
    }
}
