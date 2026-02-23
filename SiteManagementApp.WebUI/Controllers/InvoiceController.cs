using Microsoft.AspNetCore.Mvc;
using SiteManagementApp.Business.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.WebUI.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<IActionResult> Index()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return View(invoices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (!ModelState.IsValid)
                return View(invoice);
            await _invoiceService.AddAsync(invoice);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var invoice = await _invoiceService.GetByIdAsync(id);
                return View(invoice);
            }
            catch (KeyNotFoundException)
            {
                TempData["Error"] = "Invoice not found.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Invoice invoice)
        {
            if (!ModelState.IsValid)
                return View(invoice);
            await _invoiceService.UpdateAsync(invoice);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _invoiceService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
