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

        public int AddComment(Comment comment)
        {
            if (comment.CommentText.Length<=4 || comment.CommentText.Length>=301 || comment.UserName=="" || comment.Mail=="" ||  comment.UserName.Length>=50)
            {
                return -1;
            }
            return repositoryComment.Insert(comment);
        }
    }
}
