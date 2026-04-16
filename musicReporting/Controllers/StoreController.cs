using Microsoft.AspNetCore.Mvc;

namespace musicReporting.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
