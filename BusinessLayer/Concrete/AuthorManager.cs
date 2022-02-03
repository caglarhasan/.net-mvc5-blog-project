using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repositoryAuthor = new Repository<Author>();

        // Tüm Yazarları Listeleme - Get All Authors
        public List<Author> GetAllAuthor()
        {
            return repositoryAuthor.List();
        }

        // Yazar Ekleme - Add New Author
        public int AddAuthorBL(Author author)
        {
            if(author.AuthorFullName == " " || author.AuthorAboutShort == "" || author.AuthorTitle == "")
            {
                return -1;
            }
            return repositoryAuthor.Insert(author);
        }

        // Güncellemek İçin Yazarı Bulmak - Find Author For Update
        public Author FindAuthor(int id)
        {
            return repositoryAuthor.Find(x => x.AuthorId == id);
        }

        public int UpdateAuthorBL(Author p)
        {
            Author author = repositoryAuthor.Find(x => x.AuthorId == p.AuthorId);
            author.AuthorFullName = p.AuthorFullName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AuthorAboutShort = p.AuthorAboutShort;
            author.AuthorMail = p.AuthorMail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repositoryAuthor.Update(author);
        }
    }
}
