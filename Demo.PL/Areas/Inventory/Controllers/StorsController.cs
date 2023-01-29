using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class StorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
