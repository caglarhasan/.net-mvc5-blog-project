using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class UserController : Controller
    {
        UserProfileManager userProfileManager = new UserProfileManager();

        
        public ActionResult Index(string values)
        {
            var profileValues = userProfileManager.GetAuthorByMail(values);
            return View(profileValues);
        }
        
    }
}