using Business.Abstract;
using Entity.Concrate;
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
        readonly IWriterService _writerService;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager
            , IWriterService writerService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            var result = _roleManager.Roles.ToList();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> CreateRole(string id)
        {
            if (id != null)
            {
                AppRole role = await _roleManager.FindByIdAsync(id);

                return View(new RoleViewModel
                {
                    Name = role.Name
                });
            }
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
        public async Task<IActionResult> RoleAssign(int id)
        {
            var result = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            List<AppRole> allRoles = _roleManager.Roles.ToList();
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
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
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {

                if (role.HasAssign)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);

                }
                else
                {

                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                }

            }
            return RedirectToAction("UserList", "User");

        }



    }
}
