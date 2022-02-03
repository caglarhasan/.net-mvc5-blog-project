using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager blogManager = new BlogManager();
        AuthorManager authorManager = new AuthorManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetail = blogManager.GetBlogById(id);
            return PartialView(authorDetail);
        }

        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorId = blogManager.GetAll().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
            var authorBlogs = blogManager.GetBlogByAuthor(blogAuthorId).OrderByDescending(x=>x.BlogId);
            return PartialView(authorBlogs);
        }

        public ActionResult AuthorList()
        {
            var authorLists = authorManager.GetAllAuthor();
            return View(authorLists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            authorManager.AddAuthorBL(author);
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            Author author = authorManager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
        {
            authorManager.UpdateAuthorBL(author);
            return RedirectToAction("AuthorList");
        }
    }
}