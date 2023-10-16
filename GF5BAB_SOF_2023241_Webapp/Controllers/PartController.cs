using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class PartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PartController(ApplicationDbContext db, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public IActionResult DeletePart(string uid)
        {
            var item = _db.Parts.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.EngineerId == _userManager.GetUserId(this.User))
            {
                _db.Parts.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ListParts));
        }
    }
}
