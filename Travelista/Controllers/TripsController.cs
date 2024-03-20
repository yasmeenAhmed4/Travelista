
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.GenericRepository;
using Travelista.Models;
using Travelista.ViewModel;

namespace Travelista.Controllers
{
    public class TripsController : Controller
    {
        private readonly IGenericRepository<Trip> _tripsRepo;
        private readonly IGenericRepository<Country> _countryRepo;
        private readonly IGenericRepository<TripType> _tripTypeRepo;
        private readonly List<Expression<Func<Trip, bool>>> _intialPredicates;


        public TripsController(IGenericRepository<Trip> trips, IGenericRepository<TripType> TripTypeRepo, IGenericRepository<Country> countryRepo)
        {
            _tripsRepo = trips;
            _countryRepo = countryRepo;
            _tripTypeRepo = TripTypeRepo;
            _intialPredicates = new List<Expression<Func<Trip, bool>>>
                                {
                                    trip => trip.StartDate > DateTime.Now.Date,
                                    trip=>trip.Capacity>0
                                };
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await FilterAndReturnView(_intialPredicates);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm] FilterFormViewModel filterForm)
        {
            var additionalConditions = new List<Expression<Func<Trip, bool>>>();

            additionalConditions.AddRange(_intialPredicates);

            additionalConditions.AddRange(new List<Expression<Func<Trip, bool>>>
            {
                trip => filterForm.MinPrice==null || trip.Cost >= filterForm.MinPrice,
		        trip => filterForm.MaxPrice==null||trip.Cost <= filterForm.MaxPrice,
		        trip => filterForm.Country == "ALL" || (trip.Country != null && trip.Country.Name == filterForm.Country),
		        trip => filterForm.Category == "ALL" || (trip.TripType != null && trip.TripType.Name == filterForm.Category),
		        trip => filterForm.Date == null || trip.StartDate >= filterForm.Date
	        });
			return await FilterAndReturnView(additionalConditions);
		}


		private async Task<IActionResult> FilterAndReturnView(List<Expression<Func<Trip, bool>>> predicates)
        {
            var displayInfo = new TripViewModel
            {
                trips = await _tripsRepo.GetAllWithInclude(predicates, new Expression<Func<Trip, object?>>[] { trip => trip.Country, trip => trip.Images, trip => trip.TripType }).ToListAsync(),
                tripTypes = await _tripTypeRepo.GetAll().ToListAsync(),
                Countries = await _countryRepo.GetAll().ToListAsync()
            };
            return View(displayInfo);
        }
    }

}
