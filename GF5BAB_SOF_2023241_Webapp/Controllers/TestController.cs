using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestController(ApplicationDbContext db, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("../Test/ListTests", _db.Tests);
        }

        [Authorize(Roles = "Driver,Teamprincipal,Admin")]
        public IActionResult ListTests()
        {
            return View(_db.Tests);
        }

        [Authorize(Roles = "Driver,Admin")]
        public IActionResult AddTest()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> AddTest(Test test)
        {
            test.DriverId = _userManager.GetUserId(this.User);
            var old = _db.Tests.FirstOrDefault(t => t.Name == test.Name && t.DriverId == test.DriverId);
            if (old == null)
            {
                _db.Tests.Add(test);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Item created successfully!";
                return RedirectToAction(nameof(ListTests));
            }
            else
            {
                TempData["WarningMessage"] = "Item already exist!";
                return RedirectToAction(nameof(AddTest));
            }
        }

        [Authorize(Roles = "Driver,Admin")]
        public IActionResult DeleteTest(string uid)
        {
            var item = _db.Tests.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.DriverId == _userManager.GetUserId(this.User))
            {
                _db.Tests.Remove(item);
                _db.SaveChanges();
            }
            TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(ListTests));
        }

        [HttpPost]
        public IActionResult ResetSuccessMessage()
        {
            TempData["SuccessMessage"] = null;
            return Ok();
        }

        [HttpPost]
        public IActionResult ResetDeleteSuccessMessage()
        {
            TempData["DeleteSuccessMessage"] = null;
            return Ok();
        }

        [HttpPost]
        public IActionResult ResetWarningMessage()
        {
            TempData["WarningMessage"] = null;
            return Ok();
        }
    }
}
