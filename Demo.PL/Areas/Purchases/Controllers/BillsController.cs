using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Areas.Purchases.Controllers
{
    [Area("Purchases")]
    public class BillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
