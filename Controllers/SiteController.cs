using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBarcounsil.Models;
using WebMatrix.WebData;

namespace MVCBarcounsil.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult updates()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult login()
        {
            return View();
        }
        public ActionResult login1()
        {
            return View();
        }
        public ActionResult dd()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult serach()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase files, clientsinfo ob)
        {
            try
            {
                if (files.ContentLength > 0)
                {
                    string s = ob.UserName;
                    string _FileName = Path.GetFileName(files.FileName);
                    string _path = Path.Combine(Server.MapPath("~/IDPROOF"), _FileName);
                    files.SaveAs(_path);
                    string path1 = "../IDPROOF/" + _FileName;
                    common sql = new common();
                    int c = sql.Execute("insert into Clients values('" + ob.name + "','','" + ob.dob + "','" + ob.address + "','" + ob.mobile + "','" + ob.landline + "','" + ob.email + "','" + path1 + "','" + path1 + "','" + DateTime.Now.ToShortDateString() + "','" + ob.UserName + "','" + ob.passsword + "','Registred')");


                    int h = sql.Execute("insert into login values('Client','" + ob.UserName + "','" + ob.passsword + "','Active')");


                    return RedirectToAction("login", "Site");


                }
                else
                {
                    return RedirectToAction("register", "Site");
                }

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
        [AllowAnonymous]
        public string CheckUserName(string input)
        {
            bool ifuser = WebSecurity.UserExists(input);

            if (ifuser == false)
            {
                return "Available";
            }

            if (ifuser == true)
            {
                return "Not Available";
            }

            return "";
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            return Json(IsUserAvailable(UserName));


        }
        public bool IsUserAvailable(string UserName)
        {
            common sql = new common();
            clientsinfo ob = new clientsinfo();
            bool status;
            ob.dt = sql.GetData("select * from login where username='" + UserName + "'");

            if (ob.dt.Rows.Count > 0)
            {
                status = false;
            }
            else
            {
                status = true;
            }

            //Already registered  




            return status;

        }
        public ActionResult register()
        {
            return View();
        }

        //public ActionResult lawsearch()
        //{
        //    return View();
        //}

        public ActionResult validatelogin(login ob)
        {
            common sql = new common();
            ob.dt = sql.GetData("select * from login where username='" + ob.username + "' and password='" + ob.password + "'");
            if (ob.dt.Rows.Count > 0)
            {
                string status = ob.dt.Rows[0]["status"].ToString();
                if (status == "pending")
                {
                    ob.message = "Inactive User";
                    return RedirectToAction("login", "Home",ob);
                }
                else
                {
                    string type = ob.dt.Rows[0]["type"].ToString();
                    if (type == "Client")
                    {

                        clientsinfo ob1 = new clientsinfo();

                        ob1.dt = sql.GetData("select * from Clients where username='" + ob.username + "'");
                        Session["cid"] = ob1.dt.Rows[0]["clid"].ToString();
                        Session["Cname"] = ob1.dt.Rows[0]["name"].ToString();
                        Session["climg"] = ob1.dt.Rows[0]["outpath"].ToString();
                        return RedirectToAction("Home", "Client");
                    }
                    else if (type == "Advocate")
                    {
                        advinfo ob2 = new advinfo();
                        ob2.dt = sql.GetData("select * from Advocates where uname='" + ob.username + "'");
                        Session["Advid"] = ob2.dt.Rows[0]["Advid"].ToString();
                        Session["Aname"] = ob2.dt.Rows[0]["name"].ToString();
                        return RedirectToAction("Home", "Advocate");
                        //Response.Redirect("~/Advocates/Home.aspx");
                    }
                    else if (type == "Admin")
                    {
                        return RedirectToAction("Home", "Admin");
                    }
                    else
                    {
                        ob.message = "Inavlid User";
                        return RedirectToAction("login", "Site", ob);
                    }

                }
            }




            else
            {
                ob.message = "Inavlid User";
                return RedirectToAction("login", "Site", ob);

            }
            //}

        }
        public ActionResult lawsearch(string sno)
        {
            common sql = new common();
           search ob = new search();
            ob.dt = sql.GetData("select * from search where sectionno='" + sno + "'");
            if (ob.dt.Rows.Count > 0)
            {
                return View(ob);
            }
            else
            {
                ViewBag.Message = "No Recoirds Found!!";
                return View(ob);
            }




        }
    }
}
