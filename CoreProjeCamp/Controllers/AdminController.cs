using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult UserInfo()
        {
            var result = _userManager.Users;
            if (result != null)
            {
                return View(result);

            }
            else
                return View();
        }
      


    }
}
