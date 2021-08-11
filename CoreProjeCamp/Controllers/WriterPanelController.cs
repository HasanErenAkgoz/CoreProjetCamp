using Business.Abstract;
using Entity.Concrate;
using Entity.Identity;
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
        public ActionResult MyHeading(int id)
        {
            id = 1;
            var result = _headingService.GetAllById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
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
            heading.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
            _headingService.Add(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValue = (from category in _categoryService.GetAll().Data
                                                  select new SelectListItem
                                                  {
                                                      Text = category.Name,
                                                      Value = category.Id.ToString()
                                                  }).ToList();


            ViewBag.categoryValue = categoryValue;

            List<SelectListItem> writerName = (from writer in _writerService.GetAll().Data.Where(x => x.Id == 1)
                                               select new SelectListItem
                                               {
                                                   Text = writer.Name + " " + writer.Surname,
                                                   Value = writer.Id.ToString()
                                               }).ToList();

            ViewBag.writerName = writerName;
            id = 1;
            var result = _headingService.GetById(id).Data;
            return View(result);

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

    }
}
