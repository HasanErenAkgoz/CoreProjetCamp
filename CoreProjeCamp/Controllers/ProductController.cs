using Microsoft.AspNetCore.Mvc;

namespace CoreProjetCamp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
