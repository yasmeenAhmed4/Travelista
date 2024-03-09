using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{

    public class TripController : Controller
    {
        private readonly IGenericRepository<Trip> tripRepo;

        public TripController(IGenericRepository<Trip> _tripRepo)
        {
            tripRepo = _tripRepo;
        }
        public IActionResult Details(int id)
        {
            ViewBag.PopularTrips = tripRepo.GetAll()
                                            .Include(i => i.Images)
                                            .Include(i=>i.Country)
										    .AsEnumerable()
										    .Where(i => i.IsAvailable())
										    .ToList();


			var model = tripRepo.GetById(id);
            return View(model);
        }
    }
}
