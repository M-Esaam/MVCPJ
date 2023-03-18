using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
