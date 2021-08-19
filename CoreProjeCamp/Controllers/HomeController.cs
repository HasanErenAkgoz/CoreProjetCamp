using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeCamp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ICategoryService _categoryService;
        IHeadingService _headingService;
        IWriterService _writerService;
        IContentService _contentService;
        public HomeController(ICategoryService categoryService, IHeadingService headingService, IWriterService writerService, IContentService contentService)
        {
            _categoryService = categoryService;
            _headingService = headingService;
            _writerService = writerService;
            _contentService = contentService;
        }
        public IActionResult HomePage()
        {
            var categoryCount = _contentService.GetAll().Data.Count;
            ViewBag.categoryCount = categoryCount;

            var writerCount = _writerService.GetAll().Data.Count;
            ViewBag.writerCount = writerCount;

            var contentCount = _contentService.GetAll().Data.Count;
            ViewBag.contentCount = contentCount;

            var headingCount = _headingService.GetAll().Data.Count;
            ViewBag.headingCount = headingCount;
            return View();
        }
    }
}
