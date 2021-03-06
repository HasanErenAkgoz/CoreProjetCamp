using Business.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{

    public class HeadingController : Controller
    {
        IHeadingService _headingService;
        ICategoryService _categoryService;
        private IWriterService _writerService;
        public HeadingController(IHeadingService headingService, ICategoryService categoryService,
            IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;

        }

        Context context = new Context();
        [Authorize(Roles = "Admin,Yazar")]

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
        [Authorize(Roles = "Admin,Yazar")]

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
        [Authorize(Roles = "Admin,Yazar")]
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
        [HttpPost]
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
