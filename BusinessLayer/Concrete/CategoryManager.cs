using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repositoryCategory = new Repository<Category>();

        public List<Category> GetAll()
        {
            return repositoryCategory.List();
        }

        public int AddCategoryBL(Category category)
        {
            if (category.CategoryName=="" || category.CategoryDescription =="" || category.CategoryName.Length <= 3 || category.CategoryName.Length >= 30 )
            {
                return -1;
            }
            return repositoryCategory.Insert(category);
        }

        public Category FindCategory(int id)
        {
            return repositoryCategory.Find(x => x.CategoryId == id);
        }

        public int UpdateCategoryBL(Category p)
        {
            Category category = repositoryCategory.Find(x => x.CategoryId == p.CategoryId);
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return repositoryCategory.Update(category);
        }
    }
}
