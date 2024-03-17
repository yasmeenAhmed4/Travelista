using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelista.PayPalModels;
using Travelista.ViewModel;

namespace Travelista.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel newRoleVM)
        {
            if (!ModelState.IsValid)
                return View("Index" , await roleManager.Roles.ToListAsync());
            if (await roleManager.RoleExistsAsync(newRoleVM.Name))
                {
                    ModelState.AddModelError("Name", "Role Exists!");
                return RedirectToAction("Index"); // Redirect to Index action
            }
            await roleManager.CreateAsync(new IdentityRole(newRoleVM.Name.Trim()));
            return RedirectToAction("Index");
        }
    }
}
