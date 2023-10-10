using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, ApplicationDbContext db, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _db = db;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ListParts()
        {
            return View(_db.Parts);
        }

        [Authorize]

        public IActionResult AddPart()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPart(Part part)
        {
            part.EngineerId = _userManager.GetUserId(this.User);
            var old = _db.Parts.FirstOrDefault(t => t.SerialNumber == part.SerialNumber && t.EngineerId == part.EngineerId);
            if (old == null)
            {
                _db.Parts.Add(part);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ListParts));
        }

        public IActionResult Delete(string uid)
        {
            var item = _db.Parts.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.EngineerId == _userManager.GetUserId(this.User))
            {
                _db.Parts.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ListParts));
        }

            [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            return View();
        }

        public async Task<IActionResult> GetImage(string userid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == userid);
            return new FileContentResult(user.Data, user.ContentType);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}