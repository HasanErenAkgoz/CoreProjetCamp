using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjetCamp.Controllers
{
    public class ContactController : Controller
    {
        IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        ContactValidator validationRules = new ContactValidator();
        public IActionResult Index()
        {
            var result = _contactService.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View();
        }
        public IActionResult GetContactDetails(int id)
        {
            var result = _contactService.GetById(id);

            return View(result.Data);


        }
        public PartialViewResult LeftMenu()
        {
            return PartialView();
        }
    }
}
