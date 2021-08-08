using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjetCamp.Controllers
{
    public class AboutController : Controller
    {
        IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            var result = _aboutService.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(About about)
        {
            var result = _aboutService.Add(about);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public PartialViewResult partialAdd(About about)
        {
            return PartialView();
        }
    }
}
