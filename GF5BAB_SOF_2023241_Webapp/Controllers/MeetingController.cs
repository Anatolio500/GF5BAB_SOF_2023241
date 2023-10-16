using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public MeetingController(ApplicationDbContext db, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Driver,Engineer,Teamprincipal,Admin")]
        public IActionResult ListMeetings()
        {
            return View(_db.Meetings);
        }

        [Authorize(Roles = "Teamprincipal,Admin")]
        public IActionResult AddMeeting()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teamprincipal,Admin")]
        public async Task<IActionResult> AddMeeting(Meeting meeting)
        {
            meeting.TeamPrincipalId = _userManager.GetUserId(this.User);
            var old = _db.Meetings.FirstOrDefault(t => t.Name == meeting.Name && t.TeamPrincipalId == meeting.TeamPrincipalId);
            if (old == null)
            {
                _db.Meetings.Add(meeting);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ListMeetings));
        }

        [Authorize(Roles = "Teamprincipal,Admin")]
        public IActionResult DeleteMeeting(string uid)
        {
            var item = _db.Meetings.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.TeamPrincipalId == _userManager.GetUserId(this.User))
            {
                _db.Meetings.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ListMeetings));
        }
    }
}
