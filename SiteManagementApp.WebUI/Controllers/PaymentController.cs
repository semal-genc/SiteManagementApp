using Microsoft.AspNetCore.Mvc;
using SiteManagementApp.Business.Abstract;

namespace SiteManagementApp.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _paymentService.GetAllAsync();
            return View(payments);
        }

        public IActionResult MakePayment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment(int invoiceId, decimal amount)
        {
            try
            {
                await _paymentService.MakePaymentAsync(invoiceId, amount);
                return RedirectToAction("Index");
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
                await _paymentService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
