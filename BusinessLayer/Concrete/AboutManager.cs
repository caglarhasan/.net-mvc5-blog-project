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
        Repository<About> repositoryAbout = new Repository<About>();

        public List<About> GetAll()
        {
            return repositoryAbout.List();
        }

        public int UpdateAboutBL(About p)
        {
            About about = repositoryAbout.Find(x => x.AboutId == p.AboutId);
            about.AboutContent1 = p.AboutContent1;
            about.AboutContent2 = p.AboutContent2;
            about.AboutImage1 = p.AboutImage1;
            about.AboutImage2 = p.AboutImage2;
            about.AboutId = p.AboutId;
            return repositoryAbout.Update(about);
        }
    }
}
