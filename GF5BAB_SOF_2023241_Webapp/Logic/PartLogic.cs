using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Logic
{
    public class PartLogic : IPartLogic
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PartLogic(ApplicationDbContext db, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<Part> GetParts()
        {
            var parts = _db.Parts;
            return parts;
        }

        public async Task<bool> AddPart(Part part, ControllerBase controller)
        {
            part.EngineerId = _userManager.GetUserId(controller.User);
            if (_db.Parts.FirstOrDefault(t => t.SerialNumber == part.SerialNumber && t.EngineerId == part.EngineerId) != null)
            {
                return false;
            }
            _db.Parts.Add(part);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> DeletePart(string uid)
        {
            var item = _db.Parts.FirstOrDefault(t => t.Uid == uid);
            if (item == null)
            {
                return false;
            }
            _db.Parts.Remove(item);
            _db.SaveChanges();
            return false;
        }
    }
}
