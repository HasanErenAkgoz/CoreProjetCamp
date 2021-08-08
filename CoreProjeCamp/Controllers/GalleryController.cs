using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjetCamp.Controllers
{
    public class GalleryController : Controller
    {
        IImagesService _ımagesService;
        public GalleryController(IImagesService ımagesService)
        {
            _ımagesService = ımagesService;
        }
        public IActionResult Index()
        {
            var result = _ımagesService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] Image ımage)
        {
            var result = _ımagesService.Add(file, ımage);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }
    }
}
