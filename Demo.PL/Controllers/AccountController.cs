using Demo.BLL.Helper;
using Demo.BLL.Models;
using Demo.DAL.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
    
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager  ,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError("", Error.Description);
                    }
                }
            }
            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password ");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);


                    //MailSender.SendMail("password Link", passwordResetLink);


                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return RedirectToAction("ConfirmForgetPassword");
                }

                return RedirectToAction("ConfirmForgetPassword");

            }

            return View(model);
        }

        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }


        public IActionResult ResetPassword(string Email ,string Token)
        {

            if (Email==null || Token ==null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }

            return View(model);
        }

        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
    }
}
