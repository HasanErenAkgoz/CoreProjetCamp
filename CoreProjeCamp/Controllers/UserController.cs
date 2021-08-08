using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class UserController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        public UserController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult UserList()
        {
            var result = _userManager.Users.ToList();
            return View(result);
        }
    }
}
