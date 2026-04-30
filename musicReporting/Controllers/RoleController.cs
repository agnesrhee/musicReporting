using Microsoft.AspNetCore.Mvc;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace musicReporting.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IActionResult ViewAll()
        {
            RoleViewModel model = new RoleViewModel();
            model.Roles = _roleRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            RoleViewModel model = new RoleViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(RoleViewModel model)
        {
            if (model.Role == null)
            {
                ModelState.AddModelError("Role", "Role information is required.");
                return View(model);
            }
            if (_roleRepository.GetByCode(model.Role?.Code ?? string.Empty) != null)
            {
                ModelState.AddModelError("Role.Code", "A role with this code already exists.");
            }
            if (ModelState.IsValid)
            {
                // Map CategoryViewModel to Category entity and add to repository
                var role = new Role
                {
                    Code = model.Role?.Code,
                    Description = model.Role?.Description
                };

                _roleRepository.Add(role);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            RoleViewModel model = new RoleViewModel();
            model.Role = _roleRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(RoleViewModel model)
        {
            if (_roleRepository.GetByCode(model.Role?.Code ?? string.Empty) != null)
            {
                ModelState.AddModelError("Role.Code", "A role with this code already exists.");
            }
            if (ModelState.IsValid)
            {
                // Map CategoryViewModel to Category entity and update in repository
                var role = new Role
                {
                    Id = model.Role?.Id ?? 0,
                    Code = model.Role?.Code,
                    Description = model.Role?.Description
                };

                _roleRepository.Update(role);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _roleRepository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}