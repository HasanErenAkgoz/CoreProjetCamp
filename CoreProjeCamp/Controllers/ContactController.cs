using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Http;
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
                var sendMailReadCount = context.Messages.Count(x => x.sender == HttpContext.Session.GetString("Email") && x.IsRead == false).ToString();
                ViewBag.sendMailCount = sendMailReadCount;

                var receiverReardValue = context.Messages.Count(x => x.Receiver == HttpContext.Session.GetString("Email") && x.IsRead == false).ToString();
                ViewBag.receiverMailCount = receiverReardValue;

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
