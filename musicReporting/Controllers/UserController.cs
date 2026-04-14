using Microsoft.AspNetCore.Mvc;
using musicReporting.Models.Entities;
using musicReporting.Models.Interfaces;
using musicReporting.ViewModels;

namespace musicReporting.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map UserViewModel to User entity and add to repository
                var user = new User {
                    UserId = DateTime.Now.Millisecond.ToString(),
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
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map UserViewModel to User entity and update in repository
                // var user = new User { ... };
                // _userRepository.Update(user);
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
