using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        private readonly IGenericRepository<Country> _countryRepository;

        public CountryController(IGenericRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }


        [Area("Admin")]
        public ActionResult Index()
        {
            return View(_countryRepository.GetAll().ToList());
        }



        [Area("Admin")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Area("Admin")]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryRepository.Create(country);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Area("Admin")]
        public ActionResult Edit(int id)
        {
            return View(_countryRepository.GetById(id));
        }


        [HttpPost]
        [Area("Admin")]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryRepository.Update(country);
                return RedirectToAction("Index");
            }
            else
            {
                return View(country);
            }
        }

        [Area("Admin")]
        public ActionResult Delete(int id)
        {
            var country = _countryRepository.GetAll()
            .Include(t => t.Trips)
            .FirstOrDefault(t => t.Id == id);


            if (country.Trips != null && country.Trips.Any())
            {
                
                TempData["ErrorMessage"] = "Cannot delete the country because it has associated trips.";
            }
            else
            {
               
                _countryRepository.Delete(country);
            }

            return RedirectToAction("Index");
        }
    }
}
