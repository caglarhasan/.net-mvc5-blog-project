using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager
    {
        Repository<Comment> repositoryComment = new Repository<Comment>();

        public List<Comment> GetAllComments()
        {
            return repositoryComment.List();
        }
        public List<Comment> GetCommentByBlog(int id)
        {
            return repositoryComment.List(x => x.BlogId == id);
        }

        public List<Comment> GetCommentByStatusTrue()
        {
            return repositoryComment.List(x => x.CommentStatus == true);
        }

        public List<Comment> GetCommentByStatusFalse()
        {
            return repositoryComment.List(x => x.CommentStatus == false);
        }

        public int AddComment(Comment comment)
        {
            if (comment.CommentText.Length<=4 || comment.CommentText.Length>=301 || comment.UserName=="" || comment.Mail=="" ||  comment.UserName.Length>=50)
            {
                return -1;
            }
            return repositoryComment.Insert(comment);
        }

        public int UpdateCommentStatusToFalse(int id)
        {
            Comment comment = repositoryComment.Find(x => x.CommentId == id);
            comment.CommentStatus = false;
            return repositoryComment.Update(comment);
        }

        public int UpdateCommentStatusToTrue(int id)
        {
            Comment comment = repositoryComment.Find(x => x.CommentId == id);
            comment.CommentStatus = true;
            return repositoryComment.Update(comment);
        }

    }
}
