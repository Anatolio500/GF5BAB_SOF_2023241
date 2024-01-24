using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

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
            return View("../Meeting/ListMeetings", _meetingLogic.GetMeetings());
        }

        [Authorize(Roles = "Driver,Engineer,Teamprincipal,Admin")]
        public IActionResult ListMeetings()
        {
            return View(_meetingLogic.GetMeetings());
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
            /*meeting.TeamPrincipalId = _userManager.GetUserId(this.User);
            var old = _db.Meetings.FirstOrDefault(t => t.Name == meeting.Name && t.TeamPrincipalId == meeting.TeamPrincipalId);
            if (old == null)
            {
                _db.Meetings.Add(meeting);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Item created successfully!";
                return RedirectToAction(nameof(ListMeetings));
            }
            else
            {

                TempData["WarningMessage"] = "Item already exist!";
                return RedirectToAction(nameof(AddMeeting));
            }*/
            ;
            if (meeting.Name.Length > 15 || meeting.Topics.Length > 30 || meeting.StartingTime.Length > 9 || meeting.EndingTime.Length > 9)
            {
                TempData["WarningMessage"] = "Some fields are not right!";
                return View(meeting);
            }
            var succes = await _meetingLogic.AddMeeting(meeting, this);
            if (succes)
            {
                TempData["SuccessMessage"] = "Meeting created successfully!";
                return RedirectToAction(nameof(ListMeetings));
            }
            else
            {
                TempData["WarningMessage"] = "Meeting already exist!";
                return RedirectToAction(nameof(AddMeeting));
            }
        }

        [Authorize(Roles = "Teamprincipal,Admin")]
        public async Task<IActionResult> DeleteMeeting(string uid)
        {
            /*var item = _db.Meetings.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.TeamPrincipalId == _userManager.GetUserId(this.User))
            {
                _db.Meetings.Remove(item);
                _db.SaveChanges();
            }
            TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(ListMeetings));*/

            var succes = await _meetingLogic.DeleteMeeting(uid, this);
            if (succes)
            {
                TempData["DeleteSuccessMessage"] = "Item deleted successfully!";
                return RedirectToAction(nameof(ListMeetings));
            }
            else
            {
                TempData["DeleteSuccessMessage"] = "Item deleted unsuccessfully!";
                return RedirectToAction(nameof(ListMeetings));
            }

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
