using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager();
        public ActionResult Index()
        {
            var aboutContentList = aboutManager.GetAll();
            return View(aboutContentList);
        }

        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }
    }
}