using Microsoft.AspNetCore.Mvc;
using SiteManagementApp.Business.Abstract;
using SiteManagementApp.Entities.Concrete;

namespace SiteManagementApp.WebUI.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public async Task<IActionResult> Index()
        {
            var apartments = await _apartmentService.GetAllAsync();
            return View(apartments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            if (!ModelState.IsValid)
                return View(apartment);
            await _apartmentService.AddAsync(apartment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var apartment = await _apartmentService.GetByIdAsync(id);
                return View(apartment);
            }
            catch (KeyNotFoundException)
            {
                TempData["Error"] = "Apartment not found";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Apartment apartment)
        {
            if (!ModelState.IsValid)
                return View(apartment);
            await _apartmentService.UpdateAsync(apartment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apartmentService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
