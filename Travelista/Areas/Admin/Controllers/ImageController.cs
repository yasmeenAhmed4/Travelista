using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Travelista.GenericRepository;
using Travelista.Models;


namespace Travelista.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGenericRepository<Trip> _tripRepository;
        

        public ImageController(IGenericRepository<Image> imageRepository, IGenericRepository<Trip> tripRepository, IWebHostEnvironment webHostEnvironment)
        {
            _imageRepository = imageRepository;
            _tripRepository = tripRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Area("Admin")]
        public ActionResult Index()
        {
            return View(_imageRepository.GetAll().Include(t => t.Trip).ToList());
        }

        [Area("Admin")]
        public ActionResult Edit(int id)
        {

            var image = _imageRepository.GetAll()
            .Include(t => t.Trip)
            .FirstOrDefault(t => t.Id == id);

            return View(image);
        }


        [HttpPost]
        [Area("Admin")]
        public ActionResult Edit(Image image, IFormFile imageFile)
        {
           
 
            //var _image = _imageRepository.GetById(image.Id);
            //image.ImageURL = _image.ImageURL;
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var trip = _tripRepository.GetById(image.TripId);
                    // Generate a unique file name for the new image
                    var newFileName = $"{trip.Name.Replace(" ", "-")}_{image.Id}{Path.GetExtension(imageFile.FileName)}";
                    var newFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", newFileName);

                    // Save the new image file to the server
                    using (var stream = new FileStream(newFilePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    // Delete the old image file from disk
                    DeleteImageFile(image.ImageURL);

                    // Update the ImageURL property with the new file name
                    image.ImageURL = newFileName;
                }

                _imageRepository.Update(image);

                return RedirectToAction("Index");
            }
            else
            {
                return View(image);
            }
        }

        [Area("Admin")]
        public ActionResult Delete(int id)
        {
            var image = _imageRepository.GetById(id);

            // Delete the image file from disk
            DeleteImageFile(image.ImageURL);

            // Delete the image from the database
            _imageRepository.Delete(image);

            return RedirectToAction("Index");
        }

        private void DeleteImageFile(string imageUrl)
        {
            // Construct the file path from the imageUrl
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", imageUrl);

            // Check if the file exists and delete it
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}
