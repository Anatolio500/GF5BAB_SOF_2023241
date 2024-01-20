﻿using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GF5BAB_SOF_2023241_Webapp.Logic
{
    public class TestLogic
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestLogic(ApplicationDbContext db, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<Test> GetTests()
        {
            return _db.Tests;
        }

        public bool TestExists(Test test)
        {
            return _db.Tests.Any(t => t.Name == test.Name && t.DriverId == test.DriverId);
        }

        public void AddTest(Test test, ControllerBase controller)
        {
            test.DriverId = _userManager.GetUserId(controller.User);
            _db.Tests.Add(test);
            _db.SaveChanges();
        }

        public void DeleteTest(string uid, ControllerBase controller)
        {
            var item = _db.Tests.FirstOrDefault(t => t.Uid == uid);
            if (item != null && item.DriverId == _userManager.GetUserId(controller.User))
            {
                _db.Tests.Remove(item);
                _db.SaveChanges();
            }
        }
    }
}
