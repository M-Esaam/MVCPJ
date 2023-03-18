using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using BookingWebSite.ViewModel;

using BookingLibrary.Models;
using Booking.ViewModel;
using RepositoryPatternWithUOW.EF.Repository;
using RepositoryPatternWithUOW.Core.Repository;
using RepositoryEF;

namespace Booking.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWorkRepository unitOfWorkRepository;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                                   IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWorkRepository = unitOfWorkRepository;
            
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
                    //if (userModel.UserName =="Youstina")
                    //{
                    //    userManager.AddToRoleAsync(userModel, "Admin");
                    //}
                   
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

        public IActionResult PartnerRegestration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PartnerRegestration(PartnerRegaestrationViewModel partnerRegester)
        {
          

            if (ModelState.IsValid)
            {
                AppUser userModel = new AppUser();
                Hotel hotel = new Hotel();
                Hotel_Manager hotel_Manager = new Hotel_Manager();

                userModel.UserName = partnerRegester.Name;
                
                if (partnerRegester.Gender == "Male")
                {
                    userModel.gender = Gender.Male;
                }
                else
                {
                    userModel.gender = Gender.Female;
                }

              

                userModel.PasswordHash = partnerRegester.Password;
                userModel.Email = partnerRegester.Email;
                

                hotel.Name = partnerRegester.Name;
                hotel.Street = partnerRegester.HotelStreet;
                hotel.Description = partnerRegester.HotelDescription;
                hotel.Country = partnerRegester.State;
                hotel.City = partnerRegester.City;


                List<image> images = new List<image>();

                images.Add(partnerRegester.Image);
                hotel.Images = images;


               
                switch (partnerRegester.HotelRate)
                {
                    case "1": { hotel.Rate = Hotel_Rate_Star.Star; break; }

                    case "2": { hotel.Rate = Hotel_Rate_Star.TwoStars; break; }

                    case "3": { hotel.Rate = Hotel_Rate_Star.ThreeSars; break; }

                    case "4": { hotel.Rate = Hotel_Rate_Star.FourStars; break; }

                    case "5": { hotel.Rate = Hotel_Rate_Star.FiveStars; break; }

                    case "6": { hotel.Rate = Hotel_Rate_Star.SixStars; break; }

                    case "7": { hotel.Rate = Hotel_Rate_Star.SevenStars; break; }
                }

                hotel.IsConfermed = false;

                IdentityResult result = await userManager.CreateAsync(userModel, partnerRegester.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(userModel, false);

                    hotel_Manager.AppUserId = userModel.Id;
                    unitOfWorkRepository.Hotels.Add(hotel);

                    hotel.Hotel_ManagerId = userModel.Id;
                    unitOfWorkRepository.HotelManagers.Add(hotel_Manager);

                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("PartnerRegestration");
        }



        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
