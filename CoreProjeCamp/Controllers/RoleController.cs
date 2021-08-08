using Entity.Identity;
using Entity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{

    public class RoleController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        private readonly AspNetUserManager<AppUser> ıdentityUserRole;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, AspNetUserManager<AppUser> _ıdentityUserRole)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            ıdentityUserRole=_ıdentityUserRole;
        }
        public IActionResult Index()
        {
            var result = _roleManager.Roles.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {
                AppRole role = await _roleManager.FindByIdAsync(id);
                role.Name = model.Name;
                result = await _roleManager.UpdateAsync(role);
            }
            else
                result = await _roleManager.CreateAsync(new AppRole { Name = model.Name });

            if (result.Succeeded)
            {
                //Başarılı...
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                //Başarılı...
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RoleAssign(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            List<AppRole> allRoles = _roleManager.Roles.ToList();

            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;

            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }
        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("UserList", "User");
        }
    }
}
