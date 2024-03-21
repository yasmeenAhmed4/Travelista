using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.GenericRepository;
using Travelista.Models;
using Microsoft.AspNetCore.Hosting;


namespace Travelista.Areas.Admin.Controllers
{
    public class TripController : Controller
    {
        private readonly IGenericRepository<Trip> _tripRepository;
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly IGenericRepository<TripType> _tripTypeRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TripController(IGenericRepository<Trip> tripRepository, IGenericRepository<Country> countryRepository,
            IGenericRepository<TripType> tripTypeRepository, IGenericRepository<Image> imageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _tripRepository = tripRepository;
            _countryRepository = countryRepository;
            _tripTypeRepository = tripTypeRepository;
            _imageRepository = imageRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        [Area("Admin")]
        public ActionResult Index()
        {
            return View(_tripRepository.GetAll().Include(c => c.Country).Include(i => i.Images).Include(t => t.TripType).ToList());
        }


        [Area("Admin")]
        public ActionResult Details(int id)
        {
            var trip = _tripRepository.GetAll()
            .Include(t => t.TripType)
            .Include(c => c.Country)
            .Include(i => i.Images)
            .FirstOrDefault(t => t.Id == id);
            return View(trip);
        }


        [Area("Admin")]
        public ActionResult Create()
        {
            var countries = _countryRepository.GetAll().ToList();
            var types = _tripTypeRepository.GetAll().ToList();
            ViewBag.countries = countries;
            ViewBag.TripTypes = types;

            if (countries.Count == 0 || types.Count == 0)
            {
                TempData["ErrorMessage"] = "There are no countries or trip types available to add a trip.";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        [Area("Admin")]
       
        public ActionResult Create(Trip trip, List<IFormFile> imageFiles)
        {
            if (ModelState.IsValid)
            {
                // Save trip details
                _tripRepository.Create(trip);

                int imageCount = 1; // Initialize the image counter

                // Save uploaded images
                foreach (var file in imageFiles)
                {
                    if (file != null && file.Length > 0)
                    {
                        // Generate a unique file name
                        var fileName = $"{trip.Name.Replace(" ", "-")}_{imageCount}{Path.GetExtension(file.FileName)}";
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath,"images", fileName);

                        // Save the file to the server
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        // Create an Image object and set the ImageURL property
                        var imageUrl = fileName; // Assuming images are saved in the "assets/images" folder
                        var image = new Image { TripId = trip.Id, ImageURL = imageUrl };

                        // Save the Image object to the database
                        _imageRepository.Create(image);

                        imageCount++; // Increment the image counter for the next image
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.countries = _countryRepository.GetAll().ToList();
                ViewBag.TripTypes = _tripTypeRepository.GetAll().ToList();
                return View();
            }
        }



        [Area("Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.countries = _countryRepository.GetAll().ToList();
            ViewBag.TripTypes = _tripTypeRepository.GetAll().ToList();
            return View(_tripRepository.GetById(id));
        }


        [HttpPost]
        [Area("Admin")]
        public ActionResult Edit(Trip trip, List<IFormFile> imageFiles)
        {
            if (ModelState.IsValid)
            {
                // Update trip details
                var _images = _imageRepository.GetAll().Where(i => i.TripId == trip.Id).ToList();
                trip.Images = _images;
                _tripRepository.Update(trip);

                if (imageFiles.Count != 0)
                {
                    var images = _imageRepository.GetAll().Where(img => img.TripId == trip.Id).ToList();
                    foreach (var image in images)
                    {
                        DeleteImageFile(image.ImageURL); // Delete the image file from disk
                        _imageRepository.Delete(image); // Delete the image from the database
                    }
                    int imageCount = 1; // Initialize the image counter

                    // Save uploaded images
                    foreach (var file in imageFiles)
                    {
                        if (file != null && file.Length > 0)
                        {
                            // Generate a unique file name
                            var fileName = $"{trip.Name.Replace(" ", "-")}_{imageCount}{Path.GetExtension(file.FileName)}";
                            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                           
                            // Save the file to the server
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            // Create an Image object and set the ImageURL property
                            var imageUrl = fileName; // Assuming images are saved in the "assets/images" folder
                            var image = new Image { TripId = trip.Id, ImageURL = imageUrl };

                            // Save the Image object to the database
                            _imageRepository.Create(image);

                            imageCount++; // Increment the image counter for the next image
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.countries = _countryRepository.GetAll().ToList();
                ViewBag.TripTypes = _tripTypeRepository.GetAll().ToList();
                return View(trip);
            }
        }


        [Area("Admin")]
        public ActionResult Delete(int id)
        {
            var trip = _tripRepository.GetById(id);

            // Delete associated images
            var images = _imageRepository.GetAll().Where(img => img.TripId == id).ToList();
            foreach (var image in images)
            {
                DeleteImageFile(image.ImageURL); // Delete the image file from disk
                _imageRepository.Delete(image); // Delete the image from the database
            }

            // Delete the trip
            _tripRepository.Delete(trip);

            return RedirectToAction("Index");
        }

        private void DeleteImageFile(string imageUrl)
        {
            // Construct the file path from the imageUrl
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath,"images", imageUrl);

            // Check if the file exists and delete it
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}
