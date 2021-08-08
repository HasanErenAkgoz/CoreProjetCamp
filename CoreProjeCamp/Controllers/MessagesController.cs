using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Entity.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class MessagesController : Controller
    {
        IMessageService _messageService;
        MessagesValidator messagesValidator = new MessagesValidator();
        private UserManager<AppUser> _userManager;
        public MessagesController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public IActionResult Inbox()
        {
            leftMenuCount();
            var result = _messageService.GetListInbox(HttpContext.Session.GetString("Email"));
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View();
        }
        public IActionResult SendBox()
        {

            leftMenuCount();
            var result = _messageService.GetListSendBox(HttpContext.Session.GetString("Email"));
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View();
        }
        public PartialViewResult LeftMenu()
        {
            leftMenuCount();
            return PartialView();
        }
        [HttpGet]
        public IActionResult Add()
        {
            leftMenuCount();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Message message, string button)
        {
            ValidationResult validationResult = messagesValidator.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.DraftStatus = false;
                    _messageService.Add(message, HttpContext.Session.GetString("Email"));
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "draft")
            {
                if (validationResult.IsValid)
                {
                    message.DraftStatus = true;
                    _messageService.Add(message, HttpContext.Session.GetString("Email"));
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "cancel")
            {
                return RedirectToAction("Add");
            }
            return View();


        }
        public IActionResult Draft()
        {
            leftMenuCount();
            var result = _messageService.DraftList().Data;
            return View(result);
        }
        public IActionResult Trash()
        {
            leftMenuCount();
            var result = _messageService.TrashList();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View();
        }
        public IActionResult Delete(int id)
        {
            var result = _messageService.GetById(id).Data;
            _messageService.Delete(result);

            return RedirectToAction("Inbox");
        }
        public IActionResult TrashOperation(int id)
        {
            var result = _messageService.GetById(id).Data;
            _messageService.Draft(result);
            return RedirectToAction("Inbox");

        }
        public IActionResult GetMessageDetail(int id)
        {
            leftMenuCount();
            var result = _messageService.GetById(id).Data;
            IsReadValue(id);

            return View(result);
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

        public void IsReadValue(int id)
        {
            var result = _messageService.GetById(id).Data;
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            else
                result.IsRead = false;
            _messageService.Update(result);
        }
        public IActionResult IsReadValues(int id)
        {
            IsReadValue(id);

            return RedirectToAction("Inbox");
        }

        public PartialViewResult Operations()
        {
            return PartialView();
        }

    }
}
