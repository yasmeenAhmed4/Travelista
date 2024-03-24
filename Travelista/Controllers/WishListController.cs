using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using Travelista.Areas.Identity.Data;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{
	[Authorize]
	public class WishListController : Controller
	{
		private readonly IGenericRepository<WishlistItem> wishlistRepo;
		private readonly IGenericRepository<Trip> tripRepo;
		private readonly UserManager<ApplicationUser> _userManager;
		public WishListController(IGenericRepository<WishlistItem> wishlistRepo, UserManager<ApplicationUser> userManager, IGenericRepository<Trip> tripRepo)
		{
			this.wishlistRepo = wishlistRepo;
			_userManager = userManager;
			this.tripRepo = tripRepo;
		}
		public IActionResult Index()
		{
			var model = wishlistRepo.GetAll().Where(i => i.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

			return View(model);
		}
		public IActionResult AddToWishList(int id)
		{
			var existingItem = wishlistRepo.GetAll().Where(i => i.TripId == id && i.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();

			if (existingItem == null)
			{
				WishlistItem item = new WishlistItem();
				item.TripId = id;
				item.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
				wishlistRepo.Create(item);
				return Ok(new { status = 200});
			}
			else
				return NoContent(); 
		}

		public IActionResult RemoveFromWishList(int id) 
		{
			var item = wishlistRepo.GetAll().Where(i => i.TripId == id && i.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
			if(item !=null)
			{
				wishlistRepo.Delete(item);
				return RedirectToAction("Index");
			}
			else 
				return NotFound();
		}
	}
}
