using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repositoryBlog = new Repository<Blog>();

        public List<Blog> GetAll()
        {
            return repositoryBlog.List();
        }

        public List<Blog> GetBlogById(int id)
        {
            return repositoryBlog.List(x => x.BlogId == id);
        }
        
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repositoryBlog.List(x => x.AuthorId == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repositoryBlog.List(x => x.CategoryId == id);
        }

        public int BlogAddBL(Blog blog)
        {
            if(blog.BlogTitle==" " || blog.BlogImage == "" || blog.BlogTitle.Length <=5 || blog.BlogContent.Length <=100)
            {
                return -1;
            }
            return repositoryBlog.Insert(blog);
        }

        public int DeleteBlogBL(int p)
        {
            Blog blog = repositoryBlog.Find(x => x.BlogId == p);
            return repositoryBlog.Delete(blog);
        }

        public Blog FindBlog(int p)
        {
            return repositoryBlog.Find(x => x.BlogId == p);
        }

        public int UpdateBlogBL(Blog p)
        {
            Blog blog = repositoryBlog.Find(x => x.BlogId == p.BlogId);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryId = p.CategoryId;
            blog.AuthorId = p.AuthorId;
            return repositoryBlog.Update(blog);
        }
    }
}
