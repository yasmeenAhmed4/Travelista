using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{

    public class TripController : Controller
    {
        private readonly IGenericRepository<Trip> tripRepo;
		private readonly IGenericRepository<TripReView> reviewRepo;

		public TripController(IGenericRepository<Trip> _tripRepo, IGenericRepository<TripReView> reviewRepo)
		{
			tripRepo = _tripRepo;
			this.reviewRepo = reviewRepo;
		}
		public IActionResult Details(int id)
        {
            ViewBag.PopularTrips = tripRepo.GetAll().Where(i => i.IsTrend == true).ToList();

            var model = tripRepo.GetById(id);
            return View(model);
        }
        public IActionResult CreateReview(int id , string name , string email , string message)
        {
            try
            {
				TripReView r = new TripReView();
				r.TripId = id;
				r.Message = message;
				r.Username = name;
				r.Email = email;
				reviewRepo.Create(r);
				return Created();
			}catch(Exception)
			{

			}
			return NoContent();
        }
    }
}
