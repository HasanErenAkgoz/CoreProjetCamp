using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var totalCategory = context.Categories.Count().ToString();
            ViewBag.totalCategory = totalCategory;

            var numberofTitlesWithSoftwareName = context.Headings.Where(heading => heading.CategoryId == 10).Count().ToString();
            ViewBag.numberofTitlesWithSoftwareName = numberofTitlesWithSoftwareName;


            var authorsWiththeLetterAinTheirName = context.Writers.Where(w => w.Name.Contains("a") || w.Name.Contains("A")).Count();
            ViewBag.authorsWiththeLetterAinTheirName = authorsWiththeLetterAinTheirName;

            var categoryWithTheMostTitles = context.Categories.Where(u => u.Id == context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
                 .Select(x => x.Key).FirstOrDefault()).Select(x => x.Name).FirstOrDefault();
            ViewBag.categoryWithTheMostTitles = categoryWithTheMostTitles;

            var categoryStatusControl = context.Categories.Where(category => category.Status == true).Count()
                - context.Categories.Where(category => category.Status == false).Count();
            ViewBag.categoryStatusControl = categoryStatusControl;

            return View();
        }
    }
}
