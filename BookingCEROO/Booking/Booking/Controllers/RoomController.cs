using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
	public class RoomController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Details()
		{
			return View();
		}
	}
}
