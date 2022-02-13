using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {

        CategoryManager categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = categoryManager.GetAll();
            return PartialView(categoryValues);
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = categoryManager.GetAll();
            return View(categoryList);
        }
    }
}