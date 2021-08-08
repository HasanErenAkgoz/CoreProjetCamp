using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjetCamp.Controllers
{

    [AllowAnonymous]
    [Authorize(Roles ="Admin")]
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.statusCode = statusCode;
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Üzgünüm, aradığınız sayfanın adı değiştirilmiş veya geçici olarak kullanılamıyor olabilir";
                    break;
            }
            return View();

        }
       

    }
}
