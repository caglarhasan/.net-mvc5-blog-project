using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repositoryUser = new Repository<Author>();
        Repository<Blog> repositoryUserBlog = new Repository<Blog>();

        public List<Author> GetAuthorByMail(string parm)
        {
            return repositoryUser.List(x => x.AuthorMail == parm);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repositoryUserBlog.List(x => x.AuthorId == id);
        }

        public int UpdateAuthorBL(Author p)
        {
            Author author = repositoryUser.Find(x => x.AuthorId == p.AuthorId);
            author.AuthorFullName = p.AuthorFullName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AuthorAboutShort = p.AuthorAboutShort;
            author.AuthorMail = p.AuthorMail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repositoryUser.Update(author);
        }
    }
}
