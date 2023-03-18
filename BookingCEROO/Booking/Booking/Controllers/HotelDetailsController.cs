using BookingLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryEF;
using RepositoryModel.Models;

namespace Booking.Controllers
{

    public class HotelDetailsController : Controller
    {
        AppUser userModel = new AppUser();
        ApplicationDbContext context = new ApplicationDbContext();


        //kermena
       
        public IActionResult getPhotos()
        {
            Hotel hotel = context.Hotels.Where(e => e.Id == 3).Include(d => d.reviews).ThenInclude(c => c.Customer).ThenInclude(a => a.AppUser).FirstOrDefault();
            List<string> photos = context.images.Where(e => e.HotelId == 3).Select(e=>e.Name).ToList();

            List<Normal_Room> Rooms = new List<Normal_Room>();
            for (int i = 0; i < 4; i++)
            {
                Normal_Room room = context.Normals.Include(e=>e.Room).ThenInclude(e=>e.images).FirstOrDefault(e => e.Room.HotelId == 3 && ((int)e.Type_Of_Room) == i);
                if(room != null)
                {
                    Rooms.Add(room);
                }
            }

            string userName = "";
            if (Request.Cookies["UserLogin"] != null)
            {
                //= Request.Cookies["UserLogin"]["Name"].ToString();
                userName = User.Identity.Name.ToString();
            }
            ViewBag.UserName = userName;
            ViewData["photo"] = photos;
            ViewData["normal"] = Rooms;

            return View(hotel);
        }



        public IActionResult getAvailableRooms(int id)
        {
            return View();
        }

        public IActionResult getRecentComment(int id)
        {
            return View();
        }
    }
}
