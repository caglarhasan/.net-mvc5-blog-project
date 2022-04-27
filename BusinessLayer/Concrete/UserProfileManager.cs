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

        public List<Author> GetAuthorByMail(string p)
        {
            return repositoryUser.List(x => x.AuthorMail == p);
        }
    }
}
