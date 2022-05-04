using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class SubscribeMailController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult AddMail()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            SubscribeMailManager subscribeMailManager = new SubscribeMailManager();
            subscribeMailManager.BLAdd(p);
            return PartialView();
        }
    }
}