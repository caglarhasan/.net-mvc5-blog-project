using BusinessLayer.Concrete;
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
    }
}