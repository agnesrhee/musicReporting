using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;

namespace musicReporting.Controllers
{
    public class StoreInventoryController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IStoreInventoryRepository _storeInventoryRepository;

        public StoreInventoryController(IItemRepository itemRepository, IStoreRepository storeRepository, IStoreInventoryRepository storeInventoryRepository)
        {
            _itemRepository = itemRepository;
            _storeRepository = storeRepository;
            _storeInventoryRepository = storeInventoryRepository;
        }

        public IActionResult ViewAll()
        {
            StoreInventoryViewModel model = new StoreInventoryViewModel();
            model.StoreInventories = _storeInventoryRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            StoreInventoryViewModel model = new StoreInventoryViewModel();
            var stores = _storeRepository.GetAll();
            model.Stores = stores == null
                ? new List<SelectListItem>()
                : stores.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StoreName }).ToList();
            var items = _itemRepository.GetAll();
            model.Items = items == null
                ? new List<SelectListItem>()
                : items.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.ItemName }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(StoreInventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map StoreInventoryViewModel to StoreInventory entity and add to repository
                var storeInventory = new StoreInventory
                {
                    StoreId = model.StoreInventory.StoreId,
                    ItemId = model.StoreInventory.ItemId,
                    QuantityOnHand = model.StoreInventory.QuantityOnHand
                };
                _storeInventoryRepository.Add(storeInventory);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StoreInventoryViewModel model = new StoreInventoryViewModel();
            var stores = _storeRepository.GetAll();
            model.Stores = stores == null
                ? new List<SelectListItem>()
                : stores.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StoreName }).ToList();
            var items = _itemRepository.GetAll();
            model.Items = items == null
                ? new List<SelectListItem>()
                : items.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.ItemName }).ToList();
            model.StoreInventory = _storeInventoryRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StoreInventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map StoreInventoryViewModel to StoreInventory entity and update in repository
                var storeInventory = new StoreInventory
                {
                    Id = model.StoreInventory.Id,
                    StoreId = model.StoreInventory.StoreId,
                    ItemId = model.StoreInventory.ItemId,
                    QuantityOnHand = model.StoreInventory.QuantityOnHand
                };
                _storeInventoryRepository.Update(storeInventory);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _storeInventoryRepository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}

