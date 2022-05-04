using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager();
        AuthorManager authorManager = new AuthorManager();
        public ActionResult Index()
        {
            var aboutContentLists = aboutManager.GetAll();
            return View(aboutContentLists);
        }

        public PartialViewResult MeetTheTeam()
        {
            var teamMembersList = authorManager.GetAllAuthor();
            return PartialView(teamMembersList);
        }

        [HttpGet]
        public ActionResult AdminUpdateAboutList()
        {

            var aboutList = aboutManager.GetAll();
            return View(aboutList);
        }

        [HttpPost]
        public ActionResult AdminUpdateAbout(About about)
        {

            aboutManager.UpdateAboutBL(about);
            return RedirectToAction("AdminUpdateAboutList");
        }
    }
}