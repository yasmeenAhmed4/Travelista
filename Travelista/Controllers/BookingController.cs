using Microsoft.AspNetCore.Mvc;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{
    public class BookingController : Controller
    {
        private readonly IGenericRepository<Trip> tripRepo;
		public BookingController(IGenericRepository<Trip> tripRepo)
		{
			this.tripRepo = tripRepo;
		}
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOut(int id)
        {
            var trip = tripRepo.GetById(id);
            return View(trip);
        }

    }

    
}
