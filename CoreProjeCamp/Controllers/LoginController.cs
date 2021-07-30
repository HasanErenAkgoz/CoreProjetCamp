using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            var result = _loginService.AdminLogin(admin);
            if (result.Success)
            {
                var clasims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Email)
                };
                var identity = new ClaimsIdentity(
                    clasims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                HttpContext.Session.SetString("Email", admin.Email);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.ErrorMessages = "Email adresi veya Şifre hatalı lütfen tekrar deneyiniz";
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
