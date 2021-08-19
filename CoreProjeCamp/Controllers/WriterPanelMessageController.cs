using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        IMessageService _messageService;
        public WriterPanelMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        MessagesValidator messagesValidator = new MessagesValidator();

        public IActionResult Inbox()
        {
            string session = HttpContext.Session.GetString("Mail");

            leftMenuCount();
            var result = _messageService.GetListInbox(session);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View();
        }
        public IActionResult SendBox()
        {
            string session = HttpContext.Session.GetString("Mail");

            leftMenuCount();
            var result = _messageService.GetListSendBox(session);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
                return View();
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
            string session = HttpContext.Session.GetString("Mail");
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.DraftStatus = false;
                    _messageService.Add(message, session);
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
                    _messageService.Add(message, session);
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
        public PartialViewResult LeftMenu()
        {
            leftMenuCount();
            return PartialView();
        }
        public IActionResult GetMessageDetail(int id)
        {
            leftMenuCount();
            var result = _messageService.GetById(id).Data;
            IsReadValue(id);

            return View(result);
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
    }
}

