using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travelista.GenericRepository;
using Travelista.Models;
using Travelista.Data;

namespace Travelista.Areas.Admin.Controllers
{
    public class TripTypesController : Controller
    {

        private readonly IGenericRepository<TripType> _tripTypeRepository;

        public TripTypesController(IGenericRepository<TripType> tripTypeRepository)
        {
            _tripTypeRepository = tripTypeRepository;
        }


        [Area("Admin")]
        public ActionResult Index()
        {
            return View(_tripTypeRepository.GetAll().ToList());
        }

        // GET: TripTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TripTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TripTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TripTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
