using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreProjetCamp.Controllers
{
    public class HeadingController : Controller
    {
        IHeadingService _headingService;
        ICategoryService _categoryService;
        IWriterService _writerService;
        public HeadingController(IHeadingService headingService, ICategoryService categoryService,
            IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;

        }

        Context context = new Context();
        public IActionResult Index()
        {
            var result = _headingService.HeadingDTO();

            if (result.Success)
            {

                return View(result.Data);
            }
            else

                return View(result.Message);
        }
        [HttpGet]
        public IActionResult Add()
        {

            List<SelectListItem> categoryValue = (from category in _categoryService.GetAll().Data
                                                  select new SelectListItem
                                                  {
                                                      Text = category.Name,

                                                      Value = category.Id.ToString()
                                                  }).ToList();

            ViewBag.categoryValue = categoryValue;

            List<SelectListItem> writerName = (from writer in _writerService.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = writer.Name + " " + writer.Surname,
                                                   Value = writer.Id.ToString()
                                               }).ToList();

            ViewBag.writerName = writerName;


            return View();
        }
        [HttpPost]
        public IActionResult Add(Heading heading)
        {
            heading.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.Status = true;
            _headingService.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetByHeading(int id)
        {
            List<SelectListItem> categoryValue = (from category in _categoryService.GetAll().Data
                                                  select new SelectListItem
                                                  {
                                                      Text = category.Name,

                                                      Value = category.Id.ToString()
                                                  }).ToList();

            ViewBag.categoryValue = categoryValue;

            List<SelectListItem> writerName = (from writer in _writerService.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = writer.Name + " " + writer.Surname,
                                                   Value = writer.Id.ToString()
                                               }).ToList();

            ViewBag.writerName = writerName;

            var result = _headingService.GetById(id).Data;
            return View(result);
        }
        public IActionResult GetByHeading(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = _headingService.GetById(id).Data;
            _headingService.Delete(result);
            return RedirectToAction("Index");
        }
    }
}
