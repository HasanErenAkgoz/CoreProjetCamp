using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            leftMenuCount();
            var result = _contactService.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View();
            }
        }
        public IActionResult GetContactDetails(int id)
        {
            leftMenuCount();
            var result = _contactService.GetById(id);

            return View(result.Data);


        }
        public PartialViewResult LeftMenu()
        {
            //_messagesController.leftMenuCount();
            return PartialView();
        }
        public void leftMenuCount()
        {
            using (var context = new Context())
            {
                var sendMailCount = context.Messages.Count(x => x.sender == "admin@gmail.com").ToString();
                ViewBag.sendMailCount = sendMailCount;

                var receiverMailCount = context.Messages.Count(x => x.Receiver == "admin@gmail.com").ToString();
                ViewBag.receiverMailCount = receiverMailCount;

                var contactMailCount = context.Contacts.Count().ToString();
                ViewBag.contactMailCount = contactMailCount;

                var draftMailCount = context.Messages.Count(x => x.DraftStatus == true).ToString();
                ViewBag.draftMailCount = draftMailCount;

                var trashMailCount = context.Messages.Count(x => x.IsDeleted == true).ToString();
                ViewBag.trashMailCount = trashMailCount;
            }

        }


    }
}
