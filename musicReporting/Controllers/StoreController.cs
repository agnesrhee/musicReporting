using Microsoft.AspNetCore.Mvc;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.Models.Repositories;
using musicReporting.ViewModels;

namespace musicReporting.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IActionResult ViewAll()
        {
            StoreViewModel model = new StoreViewModel();
            model.Stores = _storeRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            StoreViewModel model = new StoreViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map StoreViewModel to Store entity and add to repository
                var store = new Store
                {
                    StoreName = model.Store?.StoreName,
                    PhoneNumber = model.Store?.PhoneNumber,
                    AddressLine1 = model.Store?.AddressLine1,
                    AddressLine2 = model.Store?.AddressLine2,
                    City = model.Store?.City,
                    State = model.Store?.State,
                    ZipCode = model.Store?.ZipCode
                };
                _storeRepository.Add(store);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StoreViewModel model = new StoreViewModel();
            model.Store = _storeRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map StoreViewModel to Store entity and update in repository
                var store = new Store
                {
                    StoreName = model.Store?.StoreName,
                    PhoneNumber = model.Store?.PhoneNumber,
                    AddressLine1 = model.Store?.AddressLine1,
                    AddressLine2 = model.Store?.AddressLine2,
                    City = model.Store?.City,
                    State = model.Store?.State,
                    ZipCode = model.Store?.ZipCode
                };

                _storeRepository.Add(store);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _storeRepository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}
