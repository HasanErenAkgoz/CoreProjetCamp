using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.IdentitysContext;
using Entity.Concrate;
using Entity.Identity;
using Entity.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        readonly UserManager<AppUser> _userManager;
        public WriterController(IWriterService writerService, UserManager<AppUser> userManager)
        {
            _writerService = writerService;
            _userManager = userManager;
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

        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add( Writer writer)
        {

           
            var result = _writerService.Add(writer);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> GetByWriterId(int id)
        {
            var result = _writerService.GetById(id);
            if (result != null)
            {
                return View(result.Data);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Writer writer)
        {
            var result = _writerService.Update(writer);
            if (result.Success)
            {
                return RedirectToAction("Writer", "Index");
            }
            else
                return View();
        }

    }
}
