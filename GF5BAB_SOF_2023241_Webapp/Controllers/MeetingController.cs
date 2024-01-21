using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly MeetingLogic _meetingLogic;

        public MeetingController(MeetingLogic meetingLogic)
        {
            _meetingLogic = meetingLogic;
        }

        [Authorize]
        public IActionResult Index()
        {
            var Meetings = _meetingLogic.GetMeetingList();
            return View("../Meeting/ListMeetings", Meetings);
        }

        [Authorize(Roles = "Driver,Engineer,Teamprincipal,Admin")]
        public IActionResult ListMeetings()
        {
            var Meetings = _meetingLogic.GetMeetingList();
            return View(Meetings);
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
            if (!_meetingLogic.MeetingExists(meeting))
            {
                _meetingLogic.AddMeeting(meeting);
                TempData["SuccessMessage"] = "Item created successfully!";
                return RedirectToAction(nameof(ListMeetings));
            }
            else
            {
                TempData["WarningMessage"] = "Item already exist!";
                return RedirectToAction(nameof(AddMeeting));
            }
        }

        [Authorize(Roles = "Teamprincipal,Admin")]
        public IActionResult DeleteMeeting(string uid)
        {
            _meetingLogic.DeleteMeeting(uid);
            TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(ListMeetings));
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
