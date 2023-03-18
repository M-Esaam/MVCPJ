using Booking.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
     
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleMV)
        {
            if(ModelState.IsValid)
            {  
            IdentityRole roleModel= new IdentityRole();
            roleModel.Name = roleMV.RoleName;
            IdentityResult result = await roleManager.CreateAsync(roleModel);
            if(result.Succeeded)
            {
                    return RedirectToAction("Home", "Home");

            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            }

            return View(roleMV);
        }
    }
}
