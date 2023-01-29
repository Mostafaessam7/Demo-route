using Demo.BLL.Helper;
using Demo.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class MailController : Controller
    {
        public IActionResult CreateMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMail(MailVM model)
        {

            var result = MailSender.SendMail(model);
            TempData["MSG"] = result;
            return View();
        }
    }
}
