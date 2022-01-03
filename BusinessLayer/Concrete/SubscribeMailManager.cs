using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager
    {
        Repository<SubscribeMail> repositorySubscribeMail = new Repository<SubscribeMail>();

        public int BLAdd(SubscribeMail p)
        {
            if (p.Email.Length<=10 || p.Email.Length>=50)
            {
                return -1;
            }
            return repositorySubscribeMail.Insert(p);
        }
    }
}
