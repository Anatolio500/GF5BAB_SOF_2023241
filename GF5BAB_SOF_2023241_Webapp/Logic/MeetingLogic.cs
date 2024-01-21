using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Logic
{
    public class MeetingLogic
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public MeetingLogic(ApplicationDbContext db, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<Meeting> GetMeetingList()
        {
            return _db.Meetings;
        }

        public bool MeetingExists(Meeting meeting)
        {
            return _db.Meetings.Any(t => t.Name == meeting.Name && t.TeamPrincipal == meeting.TeamPrincipal);
        }

        public void AddMeeting(Meeting meeting, ControllerBase controller)
        {
            meeting.TeamPrincipalId = _userManager.GetUserId(controller.User);
            _db.Meetings.Add(meeting);
            _db.SaveChanges();
        }

        public void DeleteMeeting (string uid, ControllerBase controller)
        {
            var item = _db.Meetings.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.TeamPrincipalId == _userManager.GetUserId(controller.User));
            {
                _db.Meetings.Remove(item);
                _db.SaveChanges();
            }
        }
    }
}
