using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

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
        public IHttpContextAccessor httpContextAccessor { get; }

        private readonly UserManager<ApplicationUser> _userManager;

		public BookingController(IGenericRepository<Booking> repository,
			IGenericRepository<Trip> tripRepository1, UserManager<ApplicationUser> userManager, IHttpContextAccessor context)
		{
			Repository = repository;
			TripRepository1 = tripRepository1;
			_userManager = userManager;
			httpContextAccessor = context;

		}
		public IActionResult Index()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var order = Repository.GetAll().Where(i => i.UserId == userId && i.Status != "canceled").ToList();
			if (order != null)
			{
				return View(order);
			}
			
			return View();
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

			var found = Repository.GetAll().Where(u => u.UserId == userId && u.TripID == id && u.Status == "booked").FirstOrDefault();
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
		public async Task<IActionResult> Charge(int tripID , long Amount , int capacity /*, int capacity, string stripeEmail, string stripeToken*/)
		{

			StripeConfiguration.ApiKey = "sk_test_51OuA9E01LplHwmYAcVztRoCEayIRGFXmyc9kiqt2uJmBd84qKV5qPrZ9EYRuzs9NsZSPGfRojfjZsrAeWEzrLJST00HXqltNM8";
        
            Booking order = new();
			order.TripID = tripID;
			order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
			order.BookDate = DateTime.Now;

			var discountAmount = (TripRepository1.GetById(tripID).Discount / 100) * Amount;

			var finalCost = Amount - discountAmount;

			order.Cost = finalCost /*TripRepository1.GetById(tripID).Cost*/;
			order.Status = "pending";
			Repository.Create(order);

			var options = new SessionCreateOptions
			{
                SuccessUrl = $"https://localhost:7188/Booking/PaymentSuccess/{order.Id}?capacity={capacity}",
				CancelUrl = "https://localhost:7188/Booking/OrderCancel/" + order.Id,
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
              
            };
			var sessionLineItem = new SessionLineItemOptions
			{
				PriceData = new SessionLineItemPriceDataOptions
				{
					UnitAmount = (long)Amount * 100,
					Currency ="usd",
					ProductData = new SessionLineItemPriceDataProductDataOptions
					{
						Name = TripRepository1.GetById(tripID).Name
					}
				},
				Quantity = 1
			};

			options.LineItems.Add(sessionLineItem);
           
            var service = new SessionService();
			Session session = await service.CreateAsync(options);

            var options1 = new PaymentIntentCreateOptions
            {
                Amount = (long)Amount * 100,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" },
               
			};
            var service2 = new PaymentIntentService();

            var paymentIntent = service2.Create(options1);

            order.StripePaymentIntentId = paymentIntent.Id;
            httpContextAccessor.HttpContext.Session.SetString("payment", paymentIntent.Id);

			order.SessionId = session.Id;
            Repository.Update(order);
            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
			//var myCharge = new Stripe.ChargeCreateOptions();
			//// always set these properties
			//myCharge.Amount = (long)(finalCost);
			//myCharge.Currency = "USD";
			//myCharge.ReceiptEmail = stripeEmail;
			//myCharge.Description = "Sample Charge";
			//myCharge.Source = stripeToken;
			//myCharge.Capture = true;
			//var chargeService = new Stripe.ChargeService();
			//Charge stripeCharge = chargeService.Create(myCharge);

			//if (stripeCharge.Status == "succeeded")
			//{
			//	Repository.Create(order);
			//	var selectedTrip = TripRepository1.GetAll().Where(i => i.Id == tripID).FirstOrDefault();
			//	selectedTrip.Capacity -= capacity;
			//	TripRepository1.Update(selectedTrip);
			//	return RedirectToAction("PaymentSuccess", "Booking");
			//}
			//else
			//{
			//	return View();
			//}
		}

		//public IActionResult OrderSuccess(int id)
		//{
		//	return View();
		//}

		public IActionResult OrderCancel(int id)
		{
			return RedirectToAction("Index", "Home");
		}
		public IActionResult PaymentSuccess(int id)
        {
			int capacity = 0;

			if (Request.Query.ContainsKey("capacity") && int.TryParse(Request.Query["capacity"], out capacity))
			{
				var order = Repository.GetById(id);
				var service = new SessionService();
				Session session = service.Get(order.SessionId);
				if (order.Status == "pending")
				{
					order.Status = "booked";
					order.BookDate = DateTime.Now;
					order.StripePaymentIntentId = session.PaymentIntentId;

				}
				Repository.Update(order);

				var selectedTrip = TripRepository1.GetAll().FirstOrDefault(i => i.Id == order.TripID);
				if (selectedTrip != null)
				{
					selectedTrip.Capacity -= capacity;
					TripRepository1.Update(selectedTrip);
				}
			}

			return View();
		}

		//order id
        public IActionResult CancelBooking(int id)
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = Repository.GetAll().Where(i => i.UserId == userId && i.Id == id && i.Status != "canceled").FirstOrDefault();
			if (order != null)
			{
                
                var options = new RefundCreateOptions
				{
					Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = order.StripePaymentIntentId
                };
				var service = new RefundService();
				Refund refund = service.Create(options);

				order.Status = "canceled";
                Repository.Update(order);
				return RedirectToAction("Index" , "Booking");
			}
			return RedirectToAction("Index", "Booking");
		}

		public IActionResult CancelBookingWithoutRefund(int id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var order = Repository.GetAll().Where(i => i.UserId == userId && i.Id == id && i.Status != "canceled").FirstOrDefault();
			if (order != null)
			{
				order.Status = "canceled";
				Repository.Update(order);
				return RedirectToAction("Index", "Booking");
			}
			return RedirectToAction("Index", "Booking");
		}
		public IActionResult Cancel(int id)
		{
			var canceled = Repository.GetById(id);
			return View(canceled);
		}
	}

}


