using Microsoft.AspNetCore.Mvc;
using Travelista.GenericRepository;
using Travelista.Models;

namespace Travelista.Controllers
{
	public class ContactController : Controller
	{
		private IGenericRepository<Contact> _repository;

        public ContactController(IGenericRepository<Contact> repository)
        {
			_repository = repository;
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SendMessage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMessage(Contact c)
		{
			if (ModelState.IsValid) 
			{
				_repository.Create(c);
			
				ModelState.Clear();

				ViewBag.msg = "Your message has been sent successfully!";
				//return RedirectToAction("SendMessage");
			}
			return View();
		}
	}
}
