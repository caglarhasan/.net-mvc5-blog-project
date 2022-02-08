using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager();
        // GET: Comment
        public PartialViewResult CommentList(int id)
        {
            var commentsLists = commentManager.GetCommentByBlog(id);
            return PartialView(commentsLists);
        }

        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            commentManager.AddComment(comment);
            return PartialView();
        }

        public ActionResult AdminCommentListTrue()
        {

            var commentsList = commentManager.GetCommentByStatusTrue();
            return View(commentsList);
        }

        public ActionResult AdminCommentListFalse()
        {

            var commentsList = commentManager.GetCommentByStatusFalse();
            return View(commentsList);
        }

        public ActionResult ChangeCommentStatusToFalse(int id)
        {
            commentManager.UpdateCommentStatusToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        public ActionResult ChangeCommentStatusToTrue(int id)
        {
            commentManager.UpdateCommentStatusToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}