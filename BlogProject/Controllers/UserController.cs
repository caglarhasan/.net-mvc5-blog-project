using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserProfileManager userProfileManager = new UserProfileManager();

        BlogManager blogManager = new BlogManager();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialSettings(string values)
        {
            var aum = (string)Session["AuthorMail"];
            values = aum;
            var profileValues = userProfileManager.GetAuthorByMail(values);
            return PartialView(profileValues);
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            userProfileManager.UpdateAuthorBL(p);
            return RedirectToAction("Index");
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["AuthorMail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = userProfileManager.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            List<SelectListItem> authors = (from x in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorFullName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();

            ViewBag.authors = authors;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.BlogAddBL(blog);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context context = new Context();
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            List<SelectListItem> authors = (from x in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorFullName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();

            ViewBag.authors = authors;

            Blog blog = blogManager.FindBlog(id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.UpdateBlog(p);
            return RedirectToAction("BlogList","User");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}