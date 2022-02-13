using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> repositoryContact = new Repository<Contact>();

        public int BLContactAdd(Contact contact)
        {
            if (contact.Mail == " " || contact.Message == " " || contact.Name==" " || contact.Surname == " " || contact.Subject == " " || contact.Mail.Length <=10 )
            {
                return -1;
            }
            return repositoryContact.Insert(contact);
        }

        public List<Contact> GetAll()
        {
            return repositoryContact.List();
        }


    }
}
