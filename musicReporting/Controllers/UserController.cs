using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace musicReporting.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IStoreRepository storeRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _storeRepository = storeRepository;
            _roleRepository = roleRepository;
        }

        public IActionResult ViewAll()
        {
            UserViewModel model = new UserViewModel();
            model.Users = _userRepository.GetAll();
            return View(model);
        }

        public IActionResult ViewUser(int id)
        {
            UserViewModel model = new UserViewModel();
            model.User = _userRepository.Get(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            UserViewModel model = new UserViewModel();
            var stores = _storeRepository.GetAll();
            model.Stores = stores == null
                ? new List<SelectListItem>()
                : stores.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StoreName }).ToList();

            var roles = _roleRepository.GetAll();
            model.Roles = roles == null
                ? new List<SelectListItem>()
                : roles.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Description }).ToList();
           

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map UserViewModel to User entity and add to repository
                var user = new User {
                    UserId = DateTime.Now.Ticks.ToString(),
                    StoreId = model.User?.StoreId,
                    RoleId = model.User?.RoleId,
                    FirstName = model.User?.FirstName,
                    LastName = model.User?.LastName,
                    UserName = model.User?.UserName,
                    Email = model.User?.Email
                };
                _userRepository.Add(user);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UserViewModel model = new UserViewModel();
            var stores = _storeRepository.GetAll();
            model.Stores = stores == null
                ? new List<SelectListItem>()
                : stores.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StoreName }).ToList();
            model.User = _userRepository.Get(id);

            var roles = _roleRepository.GetAll();
            model.Roles = roles == null
                ? new List<SelectListItem>()
                : roles.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Description }).ToList();


            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map UserViewModel to User entity and update in repository
                var user = new User {
                    Id = model.User.Id,
                    UserId = model.User.UserId,
                    StoreId = model.User.StoreId,
                    RoleId = model.User.RoleId,
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    UserName = model.User.UserName,
                    Email = model.User.Email
                };
                _userRepository.Update(user);
                return RedirectToAction("ViewAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}
