using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        readonly Repository<About> repositoryAbout = new Repository<About>();

        public List<About> GetAll()
        {
            return repositoryAbout.List();
        }
    }
}
