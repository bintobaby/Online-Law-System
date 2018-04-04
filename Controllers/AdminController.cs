using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBarcounsil.Models;
using System.IO;
using WebMatrix.WebData;


namespace MVCBarcounsil.Controllers
{
    
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        common sql = new common();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult home()
        {
            return View();
        }
        // clients=====================================================================================
        public ActionResult clientreg()
        {
            clientsinfo ob = new clientsinfo();
            ob.dt = sql.GetData("select * from Clients where status='Registred'");
            return View(ob);

        }

        //public ActionResult acceptclient(int id)
        //{


        //    int y = sql.Execute("update Clients set status='Accepted' where clid='" + id + "'");
        //    clientsinfo ob = new clientsinfo();
        //    ob.dt = sql.GetData("select * from Clients where clid ='" + id + "'");

        //    string uname = ob.dt.Rows[0]["username"].ToString();
        //    int x = sql.Execute("update login set status='Active' where username='" + uname + "'");
        //    return RedirectToAction("clientreg", "Admin");
        //}


        //public ActionResult rejectclient(int id)
        //{


        //    int y = sql.Execute("update Clients set status='Rejected' where clid='" + id + "'");
        //    clientsinfo ob = new clientsinfo();
        //    ob.dt = sql.GetData("select * from Clients where clid ='" + id + "'");

        //    string uname = ob.dt.Rows[0]["username"].ToString();
        //    int x = sql.Execute("update login set status='Pending' where username='" + uname + "'");
        //    return RedirectToAction("clientreg", "Admin");
        //}

        public ActionResult clientlists()
        {
            clientsinfo ob = new clientsinfo();
            ob.dt = sql.GetData("select * from Clients where status='Accepted'");
            return View(ob);

        }
        // clients=====================================================================================


// Advocates=======================================================================================

        public ActionResult addadvocates()
        {
            
            return View();
        }

        public ActionResult advocatelist()
        {
            advinfo ob = new advinfo();
            ob.dt = sql.GetData("select * from Advocates where status='Active'");
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

        [HttpPost]
        public ActionResult UploadFile1(HttpPostedFileBase files, advinfo ob)
        {
            try
            {
                if (files.ContentLength > 0)
                {
                    string s = ob.UserName;
                    string _FileName = Path.GetFileName(files.FileName);
                    string _path = Path.Combine(Server.MapPath("~/ADVPHOTO"), _FileName);
                    files.SaveAs(_path);
                    string path1 = "../ADVPHOTO/" + _FileName;
                    common sql = new common();
                     int c = sql.Execute("insert into Advocates values('" + ob.name+ "','" + ob.address+ "','" + ob.district + "','" + ob.mobile + "','" + ob.qualification + "','" + ob.barcounsilno + "','" +ob.specilization + "','" + ob.practicearea+ "','" + ob.court + "','" +ob.fees + "','Active','" + path1+ "','" + ob.UserName+ "','" + ob.pass+ "')");
                    
                         int d = sql.Execute("insert into login values('Advocate','" + ob.UserName + "','" + ob.pass + "','Active')");



                         return RedirectToAction("advocatelist", "Admin");
                    
                     


                }
                else
                {
                    return RedirectToAction("addadvocates", "Admin");
                }

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return RedirectToAction("addadvocates", "Admin");
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

        public ActionResult removeadv(int id)
        {
            advinfo ob = new advinfo();
           ob.dt= sql.GetData("select * from Advocates where Advid='" + id + "'");
          
               
               string  txtunamet = ob.dt.Rows[0]["uname"].ToString();
               int y = sql.Execute("update Advocates set status='Rejected' where Advid='" + id + "'");
               int x = sql.Execute("update login set status='Pending' where username='" + txtunamet + "'");
            return RedirectToAction("advocatelist", "Admin");
        }

        public ActionResult casehist()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where status='Closesd'");
            return View(ob);
        }


        public ActionResult acthist()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where status='Accepted'");
            return View(ob);
        }

// Advocates=======================================================================================
    }

}
