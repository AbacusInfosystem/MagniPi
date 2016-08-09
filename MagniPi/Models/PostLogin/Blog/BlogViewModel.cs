using MagniPi.Common;
using MagniPiBusinessEntities.Blog;
using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.Blog
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            blog = new BlogInfo();

            blogs = new List<BlogInfo>();

            Filter = new Blog_Filter();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public BlogInfo blog { get; set; }

        public List<BlogInfo> blogs { get; set; }

        public Blog_Filter Filter { get; set; }
    }

    public class Blog_Filter
    {
        //public string Blog_Name { get; set; }

        public string Month { get; set; }
        
    }

}