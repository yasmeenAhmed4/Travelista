using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travelista.Data;
using Travelista.GenericRepository;
using Travelista.Models;
using Travelista.ViewModel;

namespace Travelista.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IGenericRepository<Trip> _tripsRepo;
        private readonly IGenericRepository<Country> _countryRepo;
        private readonly IGenericRepository<TripType> _TripTypeRepo;
        private readonly Expression<Func<Trip, object>>[] _includesNav;

        public TripsController(IGenericRepository<Trip> trips, IGenericRepository<TripType> TripTypeRepo, IGenericRepository<Country> countryRepo)
        {
            _tripsRepo = trips;
            _countryRepo = countryRepo;
            _TripTypeRepo = TripTypeRepo;
            _includesNav = new Expression<Func<Trip, object>>[]
                            {
                                trip => trip.Country,
                                trip => trip.Images,
                                trip=>trip.TripType
                            };
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var predicates = new List<Expression<Func<Trip, bool>>>
            {
                trip => trip.StartDate > DateTime.Now.Date
                //trip=>trip.IsAvailable()==true
            };
            var displayInfo = new TripViewModel
            {
                trips = await _tripsRepo.GetAllWithInclude(predicates, _includesNav).ToListAsync(),
                tripTypes = _TripTypeRepo.GetAll().ToList(),
                Countries = _countryRepo.GetAll().ToList()
            };
            return View(displayInfo);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm] FilterFormViewModel filterForm)
        {
            var predicates = new List<Expression<Func<Trip, bool>>>
            {
                (trip => trip.StartDate > DateTime.Now.Date),
                (trip => trip.Cost>=filterForm.MinPrice),
                (trip => trip.Cost <= filterForm.MaxPrice),
                (trip => filterForm.Country == "ALL" || (trip.Country != null && trip.Country.Name == filterForm.Country)),
                (trip => filterForm.Category == "ALL" || (trip.TripType != null && trip.TripType.Name == filterForm.Category)),
                (trip => filterForm.Date==null || trip.StartDate>=filterForm.Date)
            };

            var displayInfo = new TripViewModel
            {
                trips = await _tripsRepo.GetAllWithInclude(predicates, _includesNav).ToListAsync(),
                tripTypes = _TripTypeRepo.GetAll().ToList(),
                Countries = _countryRepo.GetAll().ToList()
            };
            return View(displayInfo);
        }

    }
}
