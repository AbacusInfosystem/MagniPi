using MagniPi.Common;
using MagniPi.Models.PostLogin.UploadFile;
using MagniPiBusinessEntities.Attachment;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.Attachment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.UploadFile
{
    public class UploadFileController : Controller
    {
        AttachmentManager _attachmentsMan;

        public UploadFileController()
        {
            _attachmentsMan = new AttachmentManager();

        }

        public ActionResult Index(UploadFileViewModel ufViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                if (TempData["FriendlyMessage"] != null)
                {
                    ufViewModel.FriendlyMessage.Add((FriendlyMessage)TempData["FriendlyMessage"]);
                }

                pager = ufViewModel.Pager;
                
                ufViewModel.attachments = _attachmentsMan.Get_Attachments(ref pager);
                //
                //ufViewModel.Pager = pager;

                //ufViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", ufViewModel.Pager.TotalRecords, ufViewModel.Pager.CurrentPage + 1, ufViewModel.Pager.PageSize, 10, true);
                //
            }
            catch (Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                ufViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", ufViewModel);
        }

        public ActionResult Upload_File(UploadFileViewModel ufViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                if (ufViewModel.attachment.Upload_Image != null)
                {
                    string folder_Name = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["Upload_Image_Path"].ToString()), ufViewModel.attachment.File_Type_Str);

                    if (!System.IO.Directory.Exists(folder_Name))
                    {
                        System.IO.Directory.CreateDirectory(folder_Name);
                    }

                    folder_Name = folder_Name.Replace(@"/", @"\");

                    foreach (var item in ufViewModel.attachment.Upload_Image)
                    {
                        var path = "";
                        var actual_FileName = "";

                        Guid Unique_Id = Guid.NewGuid();

                        string extn = Path.GetFileName(item.FileName.Substring(item.FileName.LastIndexOf('.') + 1));

                        actual_FileName = Path.GetFileName(Unique_Id.ToString() + "." + extn);

                        path = Path.Combine(folder_Name, actual_FileName);

                        item.SaveAs(path);

                        ufViewModel.attachment.File_Name = item.FileName;
                        ufViewModel.attachment.Unique_Id = actual_FileName;
                        ufViewModel.attachment.Is_Active = true;
                        ufViewModel.attachment.Created_By = session.User_Id;
                        ufViewModel.attachment.Updated_By = session.User_Id;
                        ufViewModel.attachment.Created_On = DateTime.Now;
                        ufViewModel.attachment.Updated_On = DateTime.Now;

                        _attachmentsMan.Insert_Attachment(ufViewModel.attachment);
                    }

                }

                //ufViewModel.FriendlyMessage.Add(MessageStore.Get("ATS01"));
                TempData["FriendlyMessage"] = MessageStore.Get("ATS01");


            }
            catch (Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                //ufViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
                TempData["FriendlyMessage"] = MessageStore.Get("SYS01");
            }

            return RedirectToAction("Index", "UploadFile");
        }

        public JsonResult View_Attachment_By_Id(int Attachment_Id)
        {
            AttachmentsInfo attachment = new AttachmentsInfo();

            try
            {
                attachment = _attachmentsMan.Get_Attachment_By_Id(Attachment_Id);
                attachment.Unique_Id = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + attachment.File_Type_Str + @"\" + attachment.Unique_Id;
            }
            catch(Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());
            }

            return Json(attachment, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete_Attachment_By_Id(UploadFileViewModel ufViewModel)
        {
           
            try
            {
                
                System.IO.File.Delete(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["Upload_Image_Path"].ToString()), ufViewModel.attachment.Unique_Id));

                _attachmentsMan.Delete_Attachment_By_Id(ufViewModel.attachment.Attachment_Id);

                TempData["FriendlyMessage"] = MessageStore.Get("ATS02");
            }
            catch(Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                TempData["FriendlyMessage"] = MessageStore.Get("SYS01");

            }
            return RedirectToRoute("upload-file-1");
        }

        //
        public JsonResult Get_Attachment_By_Type(int File_Type)
        {
            List<AttachmentsInfo> attachments = new List<AttachmentsInfo>();
            PaginationInfo pager = new PaginationInfo();

            try
            {
                //pager = ufViewModel.Pager;
                attachments = _attachmentsMan.Get_Attachment_By_Type(ref pager, File_Type);

            }
            catch (Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());
            }

            return Json(attachments, JsonRequestBehavior.AllowGet);
        }
        //


    }
}
