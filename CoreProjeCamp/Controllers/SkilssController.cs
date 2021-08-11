using Business.Abstract;
using Entity.Concrate;
using Entity.Identity;
using Entity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkilssController : Controller
    {
        private readonly ISkilssCardService _skilssCard;
        private readonly UserManager<AppUser> _userManager;
        public SkilssController(ISkilssCardService skilssCard, UserManager<AppUser> userManager)
        {
            _skilssCard = skilssCard;
            _userManager = userManager;
        }
        public async Task<IActionResult> SkilssCard()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Image = user.ImagePath;
            var result = _skilssCard.GetAll();

            return View(result.Data);
        }
        [HttpGet]
        public IActionResult SkilssAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SkilssAdd(SkilssCard skilssCard)
        {
            _skilssCard.Add(skilssCard);
            return RedirectToAction("SkilssAdd");
        }
    }
}
