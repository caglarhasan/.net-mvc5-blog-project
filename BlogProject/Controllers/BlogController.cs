using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager blogManager = new BlogManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogByCategory()
        {
            return View();
        }
        public PartialViewResult BlogList()
        {
            var allBlogList = blogManager.GetAll();
            return PartialView(allBlogList);
        }

        public PartialViewResult FeaturedPosts()
        {
            return PartialView();
        }

        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }

        public PartialViewResult MailSubscribe()
        {
            return PartialView();
        }

        public ActionResult BlogDetails()
        {
            return View();
        }

        public PartialViewResult BlogCover()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadAll()
        {
            return PartialView();
        }
    }
}