using Business.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        IWriterService _writerService;
        IHeadingService _headingService;
        ICategoryService _categoryService;
        public WriterPanelController(IWriterService writerService, IHeadingService headingService, ICategoryService categoryService)
        {
            _writerService = writerService;
            _headingService = headingService;
            _categoryService = categoryService;
        }
        public IActionResult WritetrProfile()
        {

            return View();
        }
        public ActionResult MyHeading(int writerId)
        {
            using (var context = new Context())
            {

                var session = HttpContext.Session.GetString("Mail");
                writerId = context.Writers.Where(x => x.Mail == session).Select(y => y.Id).FirstOrDefault();
                var result = _headingService.GetAllById(writerId);
                if (result.Success)
                {
                    return View(result.Data);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult NewHeading()
        {
            List<SelectListItem> categoryValue = (from category in _categoryService.GetAll().Data
                                                  select new SelectListItem
                                                  {
                                                      Text = category.Name,
                                                      Value = category.Id.ToString()
                                                  }).ToList();

            ViewBag.categoryValue = categoryValue;
            return View();
        }
        [HttpPost]
        public IActionResult NewHeading(Heading heading)
        {
            using (var context = new Context())
            {
                var session = HttpContext.Session.GetString("Mail");
                var writerId = context.Writers.Where(x => x.Mail == session).Select(y => y.Id).FirstOrDefault();
                heading.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                heading.WriterId = writerId;
                _headingService.Add(heading);
                return RedirectToAction("MyHeading");
            }
        }
        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            using (var context = new Context())
            {
                var session = HttpContext.Session.GetString("Mail");
                var writerId = context.Writers.Where(x => x.Mail == session).Select(y => y.Id).FirstOrDefault();

                List<SelectListItem> categoryValue = (from category in _categoryService.GetAll().Data
                                                      select new SelectListItem
                                                      {
                                                          Text = category.Name,
                                                          Value = category.Id.ToString()
                                                      }).ToList();


                ViewBag.categoryValue = categoryValue;

                List<SelectListItem> writerName = (from writer in _writerService.GetAll().Data.Where(x => x.Id == writerId)
                                                   select new SelectListItem
                                                   {
                                                       Text = writer.Name + " " + writer.Surname,
                                                       Value = writer.Id.ToString()
                                                   }).ToList();

                ViewBag.writerName = writerName;
                var result = _headingService.GetById(id).Data;
                return View(result);
            }
        }
        [HttpPost]
        public IActionResult EditUpdate(Heading heading)
        {

            _headingService.Update(heading);
            return RedirectToAction("MyHeading");
        }
        public IActionResult Delete(int id)
        {
            var result = _headingService.GetById(id).Data;
            _headingService.Delete(result);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public IActionResult GetByWriterInfo(Writer writer)
        {
            using (var context = new Context())
            {
                var session = HttpContext.Session.GetString("Mail");
                var writerId = context.Writers.Where(x => x.Mail == session).Select(y => y.Id).FirstOrDefault();
                var result = _writerService.GetById(writerId);
                ViewBag.Image = result.Data.Image;
                if (result != null)
                {
                    return View(result.Data);

                }
                return View();
            }
        }
        [HttpPost]
        public IActionResult Update(Writer writer)
        {
            var result = _writerService.Update(writer);

            if (result.Success)
            {
                return RedirectToAction("GetByWriterInfo");
            }
            else
                return View();
        }


    }
}
