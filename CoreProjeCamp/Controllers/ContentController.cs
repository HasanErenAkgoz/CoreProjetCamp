using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class ContentController : Controller
    {
        IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public IActionResult Index()
        {
            var result = _contentService.ContentDto();
            return View(result.Data);
        }
        public IActionResult ContentByHeading(int id)
        {
            var result = _contentService.GetListId(id).Data;
            return View(result);

        }
        public IActionResult Update(Content content)
        {
            return View();
        }
    }
}
