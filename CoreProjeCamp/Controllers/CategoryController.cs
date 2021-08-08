using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoreProjeCamp.Controllers
{
    [Authorize()]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        ICategoryService _categoryService;
        IBadgeStyleService _badgeStyleService;

        public CategoryController(ICategoryService categoryService, IBadgeStyleService badgeStyleService)
        {
            _categoryService = categoryService;
            _badgeStyleService = badgeStyleService;
        }
        public IActionResult Index()
        {
            var result = _categoryService.GetAll();

            if (result.Success)
            {
                ViewBag.data = HttpContext.Session.GetString("Email");

                return View(result.Data);
            }
            return View(result.Message);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> badgeValue = (from badge in _badgeStyleService.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = badge.Name,
                                                   Value = badge.Id.ToString()
                                               }).ToList();
            ViewBag.badgeValue = badgeValue;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Heading");

        }
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult EditCategory(int id)
        {
            List<SelectListItem> badgeValue = (from badge in _badgeStyleService.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = badge.Name,
                                                   Value = badge.Id.ToString()
                                               }).ToList();
            ViewBag.badgeValue = badgeValue;
            var result = _categoryService.GetById(id);
            return View(result);
        }
        public IActionResult Update(Category category)
        {

            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}
