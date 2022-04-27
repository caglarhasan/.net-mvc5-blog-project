using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView(); 
        }

        [HttpPost]
        public PartialViewResult SendMessage(Contact contact)
        {
            contactManager.BLContactAdd(contact);
            return PartialView();
        }

        public ActionResult SendBox()
        {
            var messageList = contactManager.GetAll();
            return View(messageList);
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contactDetails = contactManager.GetContactDetails(id);
            return View(contactDetails);
        }
    }
}