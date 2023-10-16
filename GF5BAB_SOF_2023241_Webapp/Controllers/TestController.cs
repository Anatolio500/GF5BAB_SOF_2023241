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

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Driver")]
        [Authorize(Roles = "Teamprincipal")]
        public IActionResult ListTests()
        {
            return View(_db.Tests);
        }

        
        public IActionResult AddTest()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> AddTest(Test test)
        {
            test.DriverId = _userManager.GetUserId(this.User);
            var old = _db.Tests.FirstOrDefault(t => t.Name == test.Name && t.DriverId == test.DriverId);
            if (old == null)
            {
                _db.Tests.Add(test);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ListTests));
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Driver")]
        public IActionResult DeleteTest(string uid)
        {
            var item = _db.Tests.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.DriverId == _userManager.GetUserId(this.User))
            {
                _db.Tests.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ListTests));
        }
    }
}
