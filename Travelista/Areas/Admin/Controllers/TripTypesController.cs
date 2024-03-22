using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travelista.GenericRepository;
using Travelista.Models;
using Travelista.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Travelista.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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

        
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}


        [Area("Admin")]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [Area("Admin")]
        public ActionResult Create(TripType type)
        {
            if(ModelState.IsValid)
            {
                _tripTypeRepository.Create(type);
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
            return View(_tripTypeRepository.GetById(id));
        }

        
        [HttpPost]
        [Area("Admin")]
        public ActionResult Edit(TripType type)
        {
            if (ModelState.IsValid)
            {
                _tripTypeRepository.Update(type);
                return RedirectToAction("Index");
            }
            else
            {
                return View(type);
            }
        }

         [Area("Admin")]
        public ActionResult Delete(int id)
        {
            var type = _tripTypeRepository.GetAll()
            .Include(t => t.Trips)
            .FirstOrDefault(t => t.Id == id);


            if (type.Trips != null && type.Trips.Any())
            {

                TempData["ErrorMessage"] = "Cannot delete the type because it has associated trips.";
            }
            else
            {

                _tripTypeRepository.Delete(type);
            }

            return RedirectToAction("Index");
        }
    }
}
