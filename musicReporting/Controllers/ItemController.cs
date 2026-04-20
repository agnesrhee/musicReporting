using Microsoft.AspNetCore.Mvc;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.Models.Repositories;
using musicReporting.ViewModels;

namespace musicReporting.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public IActionResult ViewAll()
        {
            ItemViewModel model = new ItemViewModel();
            model.Items = _itemRepository.GetAll();
            model.Brands = _brandRepository.GetAll().Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ItemViewModel model = new ItemViewModel();
            model.Categories = _categoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            model.Brands = _brandRepository.GetAll().Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map CategoryViewModel to Category entity and add to repository
                var item = new Item
                {
                    ItemName = model.Item?.ItemName,
                    Description = model.Item?.Description,
                    CategoryId = model.Item?.CategoryId ?? 0,
                    BrandId = model.Item?.BrandId ?? 0,
                    Price = model.Item.Price,
                    SKU = model.Item?.SKU,
                    IsActive = model.Item?.IsActive ?? true
                };

                _itemRepository.Add(item);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ItemViewModel model = new ItemViewModel();
            model.Item = _itemRepository.Get(id);
            model.Categories = _categoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.Brands = _brandRepository.GetAll().Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map ItemViewModel to Item entity and update in repository
                var item = new Item
                {
                    Id = model.Item?.Id ?? 0,
                    ItemName = model.Item?.ItemName,
                    Description = model.Item?.Description,
                    Category = model.Item?.Category,
                    Brand = model.Item?.Brand,
                    Price = model.Item.Price,
                    SKU = model.Item?.SKU,
                    IsActive = model.Item?.IsActive ?? true
                };

                _itemRepository.Update(item);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _itemRepository.Delete(id);
            return RedirectToAction("ViewAll");

        }
    }
}
