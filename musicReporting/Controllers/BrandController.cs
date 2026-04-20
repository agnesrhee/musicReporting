using Microsoft.AspNetCore.Mvc;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace musicReporting.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IActionResult ViewAll()
        {
            BrandViewModel model = new BrandViewModel();
            model.Brands = _brandRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BrandViewModel model = new BrandViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map BrandViewModel to Brand entity and add to repository
                var brand = new Brand
                {
                    Name = model.Brand.Name,
                    Description = model.Brand.Description
                };

                _brandRepository.Add(brand);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BrandViewModel model = new BrandViewModel();
            model.Brand = _brandRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map BrandViewModel to Brand entity and update in repository
                var brand = new Brand
                {
                    Id = model.Brand?.Id ?? 0,
                    Name = model.Brand?.Name,
                    Description = model.Brand?.Description
                };

                _brandRepository.Update(brand);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _brandRepository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}