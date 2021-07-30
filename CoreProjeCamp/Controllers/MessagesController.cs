using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjetCamp.Controllers
{
    public class MessagesController : Controller
    {
        IMessageService _messageService;
        MessagesValidator messagesValidator = new MessagesValidator();
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Inbox()
        {
            leftMenuCount();
            var result = _messageService.GetAll();
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
            var result = _messageService.GetListSendBox();
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
        public IActionResult Add(Message message, string button)
        {
            ValidationResult validationResult = messagesValidator.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.DraftStatus = false;
                    _messageService.Add(message);
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
                    _messageService.Add(message);
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
            var result = _messageService.GetById(id).Data;
            return View(result);
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

        public PartialViewResult Operations()
        {
            return PartialView();
        }

    }
}
