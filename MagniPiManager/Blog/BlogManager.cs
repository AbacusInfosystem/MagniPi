using MagniPiBusinessEntities.Blog;
using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.Blog
{
    public class BlogManager
    {

        BlogRepo _blogRepo;

        public BlogManager()
        {
            _blogRepo = new BlogRepo();
        }

        public int Insert_Blog(BlogInfo blog)
        {
           return _blogRepo.Insert_Blog(blog);
        }

        public void Update_Blog(BlogInfo blog)
        {
            _blogRepo.Update_Blog(blog);
        }

        public List<BlogInfo> Get_Blogs(ref PaginationInfo Pager)
        {
            return _blogRepo.Get_Blogs(ref Pager);
        }

        public BlogInfo Get_Blog_By_Id(int Blog_Id)
        {
            return _blogRepo.Get_Blog_By_Id(Blog_Id);
        }

        public void Delete_Blog_By_Id(int Blog_Id)
        {
            _blogRepo.Delete_Blog_By_Id(Blog_Id);
        }

        public List<BlogInfo> Get_Blogs_By_Month(ref PaginationInfo Pager, string Month)
        {
            return _blogRepo.Get_Blogs_By_Month(ref Pager, Month);
        }

    }

}
