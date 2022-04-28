using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {

        BlogManager blogManager = new BlogManager();

        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult BlogList(int page = 1)
        {

            var allBlogList = blogManager.GetAll().OrderByDescending(x => x.BlogId).ToPagedList(page, 6);
            return PartialView(allBlogList);
        }

        public PartialViewResult FeaturedPosts()
        {
            // 1.Post
            var postId1 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();
            var postTitle1 = blogManager.GetAll().OrderByDescending(z=>z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage1 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postDate1 =  blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postId1 = postId1;
            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.postDate1 = postDate1;

            // 2.Post
            var postId2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();
            var postTitle2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postDate2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postId2 = postId2;
            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.postDate2 = postDate2;

            // 3.Post
            var postId3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();
            var postTitle3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postDate3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postId3 = postId3;
            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.postDate3 = postDate3;

            // 4.Post
            var postId4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogId).FirstOrDefault();
            var postTitle4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postDate4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postId4 = postId4;
            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.postDate4 = postDate4;

            // 5.Post
            var postId5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();
            var postTitle5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postDate5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postId5 = postId5;
            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.postDate5 = postDate5;

            return PartialView();
        }

        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }

        public ActionResult BlogDetails()
        {
            return View();
        }

        public PartialViewResult BlogCover(int id)
        {
            var blogCoverList = blogManager.GetBlogById(id);
            return PartialView(blogCoverList);
        }

        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsLists = blogManager.GetBlogById(id);
            return PartialView(blogDetailsLists);
        }

        public ActionResult BlogByCategory(int id, int page=1)
        {
            var blogListsByCategory = blogManager.GetBlogByCategory(id).OrderByDescending(x=> x.BlogId).ToPagedList(page,6);
            var categoryName = blogManager.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = categoryName;
            var categoryDescription = blogManager.GetBlogByCategory(id).Select(x => x.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = categoryDescription;
            return View(blogListsByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var adminBlogList = blogManager.GetAll();
            return View(adminBlogList);
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            blogManager.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
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
        public ActionResult UpdateBlog(Blog blog)
        {
            blogManager.UpdateBlog(blog);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommentsByBlog(int id)
        {
            CommentManager commentManager = new CommentManager();
            var commentsLists = commentManager.GetCommentByBlog(id);
            return PartialView(commentsLists);
        }
    }
}