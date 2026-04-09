using Microsoft.AspNetCore.Mvc;

namespace musicReporting.Controllers
{
    public class UserController : Controller
    {
        public IActionResult ViewAll()
        {
            return View();
        }
    }
}
