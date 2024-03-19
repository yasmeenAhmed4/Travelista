using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.Areas.Identity.Data;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IGenericRepository<Trip> _tripRepository;
        private readonly IGenericRepository<Contact> _contactRepository;
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public AdminController(IGenericRepository<Booking> bookingRepository, IGenericRepository<Trip> tripRepository,UserManager<ApplicationUser> userManager,
            IGenericRepository<Contact> contactRepository, IGenericRepository<Country> countryRepository)
        {
            _bookingRepository = bookingRepository;
            _tripRepository = tripRepository;
            _userManager = userManager;
            _contactRepository = contactRepository;
            _countryRepository= countryRepository;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.Booking = _bookingRepository.GetAll().Include(t => t.Trip).Include(u => u.ApplicationUser).ToList();
            ViewBag.bookingNum = _bookingRepository.GetAll().ToList().Count();
            ViewBag.tripsNum   = _tripRepository.GetAll().ToList().Count();
            ViewBag.users = _userManager.GetUsersInRoleAsync(Role.User).Result.Count();
            ViewBag.contact = _contactRepository.GetAll().ToList();
            ViewBag.country = _countryRepository.GetAll().ToList().Count();
            return View();
        }

    }
}
