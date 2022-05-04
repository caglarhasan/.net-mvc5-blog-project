using BusinessLayer.Concrete;
using EntityLayer.Concrete;
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


        [AllowAnonymous]
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

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
            categoryManager.AddCategoryBL(category);
            return RedirectToAction("AdminCategoryList", "Category");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            Category category = categoryManager.FindCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            categoryManager.UpdateCategoryBL(p);
            return RedirectToAction("AdminCategoryList", "Category");
        }
    }
}