using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using Travelista.Areas.Identity.Data;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{
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
			var model = wishlistRepo.GetAll().AsEnumerable().Where(i => i.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

			return View(model);
		}
		public async Task<IActionResult> AddToWishList(int id)
		{
			WishlistItem item = new();
			item.TripId = id;
			item.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
			try
			{
				wishlistRepo.Create(item);
				return Created();
			}
			catch (Exception)
			{

				
			}
			return NoContent();
		}
	}
}
