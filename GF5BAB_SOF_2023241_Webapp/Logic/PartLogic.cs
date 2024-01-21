using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Logic
{
    public class PartLogic
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

        public IEnumerable<Part> GetPartsList()
        {
            return _db.Parts;
        }

        public bool PartExists(Part part)
        {
            return _db.Parts.Any(t => t.SerialNumber == part.SerialNumber && t.EngineerId == part.EngineerId);
        }

        public bool PartExistsUid(string uid)
        {
            return _db.Parts.Any(t => t.Uid == uid);
        }

        public async void AddPart(Part part, ControllerBase controller)
        {
            part.EngineerId = _userManager.GetUserId(controller.User);
            _db.Parts.Add(part);
            _db.SaveChanges();
        }

        public async void DeletePart(string uid)
        {
            var item = _db.Parts.FirstOrDefault(t => t.Uid == uid);
            _db.Parts.Remove(item);
            _db.SaveChanges();
        }
    }
}
