using Business.Abstract;
using Entity.Concrate;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreProjetCamp.Controllers
{
    public class DefaultController : Controller
    {
        IHeadingService _headingService;
        IContentService _contentService;
        public DefaultController(IHeadingService headingService, IContentService contentService)
        {
            _headingService = headingService;
            _contentService = contentService;
        }
        public PartialViewResult Index()
        {
            var result = _contentService.ContentDto();
            if (result.Success)
            {
                return PartialView(result.Data);

            }
            return PartialView();
        }
        public IActionResult Heading(int page=1)

        {
            var result = _headingService.HeadingDTO();
            if (result.Success)
            {
                return View(result.Data.ToPagedList(page,5));

            }
            return View();
        }
        public IActionResult HeadingContent(int id)
        {
            var result = _contentService.GetListId(id).Data;
            return View(result);
        }

    }
}
