using MagniPi.Models.PreLogin;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagniPiManager.Authentication;
using MagniPi.Common;
using System.Web.Security;
using System.Configuration;

namespace MagniPi.Controllers.PreLogin
{
    public class AuthenticationController : Controller
    {
        AuthenticationManager _authMan;

        public AuthenticationController()
        {
            _authMan = new AuthenticationManager();
        }

        public ActionResult AuthenticateUser(AuthenticationViewModel authViewModel)
        {
            try
            {

                SessionInfo session = _authMan.AuthernticateLogin(authViewModel.Session);

                if (session.User_Name == authViewModel.Session.User_Name)
                {

                    SetUsersSession(session);

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["FriendlyMessage"] = MessageStore.Get("SYS03");
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Authentication : " + ex.Message);

                HttpContext.Session.Clear();

                TempData["FriendlyMessage"] = MessageStore.Get("SYS01");

                return RedirectToAction("Index", "Home");

            }
        }

        private void SetUsersSession(SessionInfo session)
        {
            try
            {

                if (HttpContext.Session["SessionInfo"] == null)
                {
                    HttpContext.Session.Add("SessionInfo", session);
                }
                else
                {
                    HttpContext.Session["SessionInfo"] = session;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Authentication : " + ex.Message);

                HttpContext.Session.Clear();

                TempData["FriendlyMessage"] = MessageStore.Get("SYS01");
            }
        }

        public ActionResult Logout(string timeOut)
        {
            AuthenticationViewModel authViewModel = new AuthenticationViewModel();

            try
            {
                LogoutUser();
                if (timeOut == "Timeout")
                {
                    TempData["FriendlyMessage"] = MessageStore.Get("SYS02");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Logout : " + ex.Message);

                TempData["FriendlyMessage"] = MessageStore.Get("SYS01");
            }

            return RedirectToAction("Index", "Home");
        }

        private void LogoutUser()
        {
            Session["SessionInfo"] = null;

            //Session["ReturnURL"] = null;

            FormsAuthentication.SignOut();

            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);

            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";

            Response.AddHeader("Cache-Control", "no-cache");

            Response.Cache.SetNoStore();

            Response.AddHeader("Pragma", "no-cache");

            //  Response.Redirect("/");
        }



    }
}
