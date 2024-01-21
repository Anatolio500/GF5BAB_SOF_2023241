using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Meeting> GetMeetings()
        {
            var meetings = _db.Meetings;
            return meetings;
        }

        public async Task<bool> AddMeeting(Meeting meeting, ControllerBase controller)
        {
            ;
            meeting.TeamPrincipalId = _userManager.GetUserId(controller.User);
            if ((_db.Meetings.FirstOrDefault(t => t.Name == meeting.Name && t.TeamPrincipalId == meeting.TeamPrincipalId)) != null)
            {
                return false;
            }
            _db.Meetings.Add(meeting);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteMeeting(string uid, ControllerBase controller)
        {
            var item = _db.Meetings.FirstOrDefault(t => t.Uid == uid);
            if (item == null)
            {
                return false;
            }
            _db.Meetings.Remove(item);
            _db.SaveChanges();
            return true;
        }
    }
}
