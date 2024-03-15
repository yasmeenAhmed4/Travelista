using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IGenericRepository<Trip> _repository;
		public HomeController(ILogger<HomeController> logger , IGenericRepository<Trip> repository)
		{
			_logger = logger;
			_repository = repository;
		}

		public IActionResult Index()
		{
			var AllTrendingTrip = _repository.GetAll().Include(t => t.Images).Include(c=>c.Country).ToList().Where(t => t.IsTrend == true && t.IsAvailable()==true).ToList();
			ViewBag.AllDiscountedTrip = _repository.GetAll().Include(t => t.Images).Include(c => c.Country).ToList().Where(t => t.Discount > 0 && t.IsAvailable() == true).ToList();
			return View(AllTrendingTrip);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
