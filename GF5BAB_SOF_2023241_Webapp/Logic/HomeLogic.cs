﻿using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;

namespace GF5BAB_SOF_2023241_Webapp.Logic
{
    public class HomeLogic
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeLogic(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> GrantRole (string uid, string role)
        {
            var user = await _userManager.FindByIdAsync(uid);
            if (user == null)
            {
                return false;
            }
            await _userManager.AddToRoleAsync(user, role);
            return true;
        }

        public async Task<bool> RemoveRole (string uid, string role)
        {
            var user = await _userManager.FindByIdAsync(uid);
            if (user == null)
            {
                return false;
            }
            await _userManager.RemoveFromRoleAsync(user, role);
            return true;
        }
    }
}
