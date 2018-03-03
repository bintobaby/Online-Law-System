using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SodetsoUsersManagement.Models;
using SodetsoUsersManagement.Services;
using System.Web.Security;
namespace SodetsoUsersManagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        HomeService _HomeService = new HomeService();

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "Dashboard";
                return View(_HomeService.DashboardStats());
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        public ActionResult Login()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult WebLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _HomeService.UserAuthenticate(model);

                if (loginResult.Email != null && loginResult.UserID != 0)
                {                   
                    Session["UserID"] = loginResult.UserID.ToString();
                    Session["Email"] = loginResult.Email.ToString();
                    Session["Firstname"] = loginResult.Firstname.ToString();
                    Session["Position"] = loginResult.Position.ToString();

                    model.Password = string.Empty;

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return RedirectToAction("Login");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login");
        }
    }
}
