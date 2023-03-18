using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using BookingWebSite.ViewModel;

using BookingLibrary.Models;

namespace Booking.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Regestration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regestration(RegestrationViewModel userRegister)
        {

            if (ModelState.IsValid)
            {
                AppUser userModel = new AppUser();
                userModel.UserName = userRegister.Name;
                userModel.PasswordHash = userRegister.Password;
                userModel.Email = userRegister.Email;
               // userModel.Address = userRegister.Address;

                if (userRegister.Gender == "Male")
                {
                    userModel.gender = Gender.Male;
                }
                else
                {
                    userModel.gender = Gender.Female;
                }

                IdentityResult result = await userManager.CreateAsync(userModel, userRegister.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(userModel, false);
                    return Content("Done");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                AppUser userModel = await userManager.FindByNameAsync(loginUser.Name);

                if (userModel != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.
                        PasswordSignInAsync(userModel, loginUser.Password, loginUser.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return View("Regestration");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong data");
                }
            }

            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
