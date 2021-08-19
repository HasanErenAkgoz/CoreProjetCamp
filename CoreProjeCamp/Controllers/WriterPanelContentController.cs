using Business.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        IContentService _contentService;
        public WriterPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public IActionResult Index(string session)
        {
            using (var context = new Context())
            {
                session = HttpContext.Session.GetString("Mail");
                var writerId = context.Writers.Where(x => x.Mail == session).Select(y => y.Id).FirstOrDefault();
                var result = _contentService.GetListByWriterId(writerId).Data;
                return View(result);
            }


        }
        [HttpGet]
        public IActionResult AddHeading(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Content content)
        {
            using (var context = new Context())
            {
                string session;
                session = HttpContext.Session.GetString("Mail");
                var writerId = context.Writers.Where(x => x.Mail == session).Select(y => y.Id).FirstOrDefault();
                content.WriterId = writerId;
                _contentService.Add(content);
                return RedirectToAction("Index");
            }

        }

    }
}
