using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.IdentitysContext;
using Entity.Concrate;
using Entity.Identity;
using Entity.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoreProjetCamp.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IActionResult Index()
        {

            var result = _writerService.GetAll();
            if (result != null)
            {
                return View(result.Data);
            }
            return View(result.Message);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Writer writer)
        {


            writer.Status = true;
            _writerService.Add(writer);
            return RedirectToAction("Index");


        }

    }
}
