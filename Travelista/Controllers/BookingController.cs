using Microsoft.AspNetCore.Mvc;

namespace Travelista.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }

    }

    
}
