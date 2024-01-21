using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly HomeLogic _homeLogic;

        public HomeController(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, ApplicationDbContext db, IEmailSender emailSender, HomeLogic homeLogic)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _db = db;
            _emailSender = emailSender;

            _homeLogic = homeLogic;
        }

        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdmin(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.RemoveFromRoleAsync(user, "Admin");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.RemoveRole(uid, "Admin");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantAdmin(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.AddToRoleAsync(user, "Admin");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.GrantRole(uid, "Admin");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveDriver(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.RemoveFromRoleAsync(user, "Driver");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.RemoveRole(uid, "Driver");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantDriver(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.AddToRoleAsync(user, "Driver");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.GrantRole(uid, "Driver");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveEngineer(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.RemoveFromRoleAsync(user, "Engineer");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.RemoveRole(uid, "Engineer");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantEngineer(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.AddToRoleAsync(user, "Engineer");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.GrantRole(uid, "Engineer");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveTeamprincipal(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.RemoveFromRoleAsync(user, "Teamprincipal");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.RemoveRole(uid, "Teamprincipal");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantTeamprincipal(string uid)
        {
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            //await _userManager.AddToRoleAsync(user, "Teamprincipal");
            //return RedirectToAction(nameof(Users));
            var success = await _homeLogic.GrantRole(uid, "Teamprincipal");
            if (success)
            {
                return RedirectToAction(nameof(Users));
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
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
            //var user = _userManager.Users.FirstOrDefault(t => t.Id == userid);
            //return new FileContentResult(user.Data, user.ContentType);
            var result = await _homeLogic.GetImage(userid);
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}