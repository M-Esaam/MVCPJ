using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
	public class PaymentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
