using Microsoft.AspNetCore.Mvc;
using Demo.BLL.Models;
using Demo.DAL.Migrations;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var data = roleManager.Roles;
            return View(data);
        }

        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = model.RoleName
                };

                var res = await roleManager.CreateAsync(role);
                if (res.Succeeded)
                {
                    return RedirectToAction("CreateRole");

                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }

        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            var data = new EditRoleVM()
            {
                RoleName = role.Name,
                Id = role.Id
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {

            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);
                role.Name=model.RoleName;
                var res= await roleManager.UpdateAsync(role);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }






        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            var data = new DeleteRoleVM()
            {
                RoleName = role.Name,
                Id = role.Id
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(DeleteRoleVM model)
        {

            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);
                
                var res = await roleManager.DeleteAsync(role);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }



    }
}
