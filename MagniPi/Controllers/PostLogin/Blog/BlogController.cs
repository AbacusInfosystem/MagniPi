using MagniPi.Common;
using MagniPi.Models.PostLogin.Blog;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.Blog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Blog
{
    public class BlogController : Controller
    {

        BlogManager _blogMan;

        public BlogController()
        {
            _blogMan = new BlogManager();
        }

        public ActionResult Search(BlogViewModel bViewModel)
        {
            
            try
            {
              
                
            }
            catch(Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Search", bViewModel);
        }

        public JsonResult Get_Blogs(BlogViewModel bViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = bViewModel.Pager;

                if (!string.IsNullOrEmpty(bViewModel.Filter.Month))
                {
                    bViewModel.blogs = _blogMan.Get_Blogs_By_Month(ref pager, bViewModel.Filter.Month);
                }
                else
                {
                    bViewModel.blogs = _blogMan.Get_Blogs(ref pager);
                }
                
                bViewModel.Pager = pager;

                bViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", bViewModel.Pager.TotalRecords, bViewModel.Pager.CurrentPage + 1, bViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Blog Controller - Get_Blogs " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(bViewModel);
        }

        public ActionResult Index(BlogViewModel bViewModel)
        {
            try
            {
                if(bViewModel.blog.Blog_Id != 0)
                {
                    bViewModel.blog = _blogMan.Get_Blog_By_Id(bViewModel.blog.Blog_Id);

                    bViewModel.blog.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + bViewModel.blog.File_Type_Str + @"\" + bViewModel.blog.Header_Image_Url;
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", bViewModel);
        }

        public ActionResult Save_Blog(BlogViewModel bViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                bViewModel.blog.Updated_By = session.User_Id;
                bViewModel.blog.Updated_On = DateTime.Now;
                bViewModel.blog.Created_By = session.User_Id;
                bViewModel.blog.Created_On = DateTime.Now;

                if (bViewModel.blog.Blog_Id != 0)
                {
                    _blogMan.Update_Blog(bViewModel.blog);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("BLG02"));
                
                }
                else
                {
                    
                    bViewModel.blog.Blog_Id = _blogMan.Insert_Blog(bViewModel.blog);

                    bViewModel.FriendlyMessage.Add(MessageStore.Get("BLG01"));
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", bViewModel);
        }





    }
}
