using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Climate;
using System.Net;
using System.Security.Claims;
using Travelista.Areas.Identity.Data;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{
	[Authorize]
	public class BookingController : Controller
	{
		public IGenericRepository<Booking> Repository { get; }
		public IGenericRepository<Trip> TripRepository1 { get; }

		private readonly UserManager<ApplicationUser> _userManager;

		public BookingController(IGenericRepository<Booking> repository,
			IGenericRepository<Trip> tripRepository1, UserManager<ApplicationUser> userManager)
		{
			Repository = repository;
			TripRepository1 = tripRepository1;
			_userManager = userManager;
		}
		public ICollection<Booking> Index()
		{

			return Repository.GetAll().Include(o => o.ApplicationUser).ToList();
		}
		// trip id
		public async Task<IActionResult> CheckOut(int id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				return NotFound("User not found.");
			}

			var firstName = user.FirstName;
			var lastName = user.LastName;
			var email = user.Email;
			ViewBag.FirstName = firstName;
			ViewBag.LastName = lastName;
			ViewBag.Email = email;

			var found = Repository.GetAll().Where(u => u.UserId == userId && u.TripID == id).FirstOrDefault();
			if(found == null)
			{
				ViewBag.found = true;
			}
			else
			{
                ViewBag.found = false;
            }
            return View(TripRepository1.GetById(id));
		}
		
		[HttpPost]
		public IActionResult Charge(int tripID ,string stripeEmail, string stripeToken)
		{

			Booking order = new();
			order.TripID = tripID;
			order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			order.BookDate = DateTime.Now;
			order.Cost = TripRepository1.GetById(tripID).Cost;

			var myCharge = new Stripe.ChargeCreateOptions();
			// always set these properties
			myCharge.Amount = (long)(order.Cost * 100);
			myCharge.Currency = "USD";
			myCharge.ReceiptEmail = stripeEmail;
			myCharge.Description = "Sample Charge";
			myCharge.Source = stripeToken;
			myCharge.Capture = true;
			var chargeService = new Stripe.ChargeService();
			Charge stripeCharge = chargeService.Create(myCharge);

			if (stripeCharge.Status == "succeeded")
			{
				Repository.Create(order);
				var selectedTrip = TripRepository1.GetAll().Where(i => i.Id == tripID).FirstOrDefault();
				selectedTrip.Capacity -= 1;
				TripRepository1.Update(selectedTrip);
				return RedirectToAction("PaymentSuccess", "Booking");
			}
			else
			{
				return View();
			}
		}
        public IActionResult PaymentSuccess()
        {
			return View();
        }
	}
}


