using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;

namespace musicReporting.Controllers
{
    public class SaleController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleLineItemRepository _saleLineItemRepository;
        private readonly IStoreInventoryRepository _storeInventoryRepository;

        public SaleController(IItemRepository itemRepository, IStoreRepository storeRepository, ISaleRepository saleRepository, 
            ISaleLineItemRepository saleLineItemRepository, IStoreInventoryRepository storeInventoryRepository)
        {
            _itemRepository = itemRepository;
            _storeRepository = storeRepository;
            _saleRepository = saleRepository;
            _saleLineItemRepository = saleLineItemRepository;
            _storeInventoryRepository = storeInventoryRepository;
        }
        [HttpGet]
        public IActionResult ViewAll()
        {
            SaleViewModel model = new SaleViewModel();
            model.Sales = _saleRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult ViewSale(int id)
        {
            var sale = _saleRepository.Get(id);

            if (sale == null)
            {
                return NotFound();
            }

            SaleViewModel model = new SaleViewModel();
            model.Sale = sale;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SaleViewModel model = new SaleViewModel();

            model.Stores = _storeRepository.GetAll()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.StoreName
                }).ToList();

            model.Items = _itemRepository.GetAll()
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.ItemName
                }).ToList();

            model.LineItems.Add(new SaleLineItemInput());
            model.LineItems.Add(new SaleLineItemInput());
            model.LineItems.Add(new SaleLineItemInput());

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Stores = _storeRepository.GetAll()
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.StoreName
                    }).ToList();

                model.Items = _itemRepository.GetAll()
                    .Select(i => new SelectListItem
                    {
                        Value = i.Id.ToString(),
                        Text = i.ItemName
                    }).ToList();

                return View(model);
            }

            var sale = new Sale
            {
                StoreId = model.StoreId,
                UserId = model.UserId,
                SaleDate = DateTime.Now
            };

            _saleRepository.Add(sale);

            foreach (var line in model.LineItems)
            {
                if (line.ItemId == null || line.Quantity <= 0)
                {
                    continue;
                }

                var item = _itemRepository.Get(line.ItemId.Value);

                if (item == null)
                {
                    continue;
                }

                var saleLineItem = new SaleLineItem
                {
                    SaleId = sale.Id,
                    ItemId = line.ItemId.Value,
                    Quantity = line.Quantity,
                    UnitPrice = item.Price
                };

                _saleLineItemRepository.Add(saleLineItem);

                var inventory = _storeInventoryRepository.GetByStoreAndItem(model.StoreId, line.ItemId.Value);

                if (inventory == null)
                {
                    return Content("This item is not stocked at the selected store.");
                }

                if (inventory.QuantityOnHand < line.Quantity)
                {
                    return Content($"Not enough stock for item {item.ItemName}. Available: {inventory.QuantityOnHand}");
                }

                if (inventory != null)
                {
                    inventory.QuantityOnHand -= line.Quantity;
                    _storeInventoryRepository.Update(inventory);
                }
            }

            return Content($"Sale saved with Id = {sale.Id}");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sale = _saleRepository.Get(id);

            if (sale == null)
            {
                return NotFound();
            }

            _saleRepository.Delete(id);

            return RedirectToAction("ViewAll");
        }
    }
}
