using Microsoft.AspNetCore.Mvc;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace musicReporting.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult ViewAll()
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Categories = _categoryRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CategoryViewModel model = new CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map CategoryViewModel to Category entity and add to repository
                var category = new Category
                {
                   Name = model.Category?.Name,
                   Description = model.Category?.Description
                };

                _categoryRepository.Add(category);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Category = _categoryRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map CategoryViewModel to Category entity and update in repository
                var category = new Category
                {
                    Id = model.Category?.Id ?? 0,
                    Name = model.Category?.Name,
                    Description = model.Category?.Description
                };

                _categoryRepository.Update(category);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}