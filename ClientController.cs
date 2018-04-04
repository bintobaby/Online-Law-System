using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBarcounsil.Models;
using System.IO;

namespace MVCBarcounsil.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        common sql = new common();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult home()
        {
            return View();
        }
        public ActionResult law()
        {
            return View();
        }
// regiseer case===============================================================================

        public ActionResult advocatelist(string district)
        {

            advinfo ob = new advinfo();
            ob.dt = sql.GetData("select * from Advocates where status='Active' and district='"+ district + "'");
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
        public ActionResult regcase(int id)
        {
            caseinfo ob = new caseinfo();
            ob.dt=sql.GetData("SELECT * FROM Advocates where Advid='"+id+"'");
            ob.advid = ob.dt.Rows[0]["Advid"].ToString();
            ob.advname = ob.dt.Rows[0]["name"].ToString();
            ob.fee = ob.dt.Rows[0]["fees"].ToString();
            ob.advimg = ob.dt.Rows[0]["photo"].ToString();
            ob.category = ob.dt.Rows[0]["specilization"].ToString();
            return View(ob);

        }

        public ActionResult inscae(caseinfo ob)
        {

            int c = sql.Execute("insert into Cases values('" + Session["cid"].ToString() + "','" + Session["Cname"].ToString() + "','" + ob.advid+ "','" + ob.advname + "','" +ob.category + "','" + ob.court+ "','" + ob.description + "','" + ob.fee + "','" + System.DateTime.Now.ToShortDateString()+ "','Registred','','','" + Session["climg"].ToString() + "','" + ob.advimg + "')");
            return RedirectToAction("reviewcase", "Client");
        }

        public ActionResult reviewcase()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where clientid='" + Session["cid"].ToString() + "'");
            return View(ob);
          
               
        }

        public ActionResult caselistclient()
        {
            caseinfo ob = new caseinfo();

            ob.dt = sql.GetData("select * from Cases where clientid='" + Session["cid"].ToString() + "' and  status='Accepted'");

            return View(ob);

        }

        public ActionResult viewupdateclient(int id)
        {
            caseupdates ob = new caseupdates();

            ob.dt = sql.GetData("select * from  Updates where caseid='" + id + "' order by updid");
            ob.caseid = id.ToString();
            return View(ob);

        }
        public ActionResult advocatesearch()
        
        {
            return View();
        }

        public ActionResult uploadfile(int id)
        {
            casefiles ob = new casefiles();
           ob.dt= sql.GetData("select * from Cases where caseid='"+id+"'");
           ob.caseid = ob.dt.Rows[0]["caseid"].ToString();
           return View(ob);
        }

        [HttpPost]
        public ActionResult UploadFile3(HttpPostedFileBase files, casefiles ob)
        {
            try
            {
                if (files.ContentLength > 0)
                {
                   
                    string _FileName = Path.GetFileName(files.FileName);
                    string _path = Path.Combine(Server.MapPath("~/CASEFILES"), _FileName);
                    files.SaveAs(_path);
                    string path1 = "../../CASEFILES/" + _FileName;
                    common sql = new common();
                    int c = sql.Execute("insert into uploads values('" + ob.caseid + "','" + path1+ "','" + ob.descri + "')");



                    return RedirectToAction("caselistclient", "Client");




                }
                else
                {
                    return RedirectToAction("caselistclient", "Client");
                }

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return RedirectToAction("caselistclient", "Client");
            }
        }

        public ActionResult viewfiles(int id)
        {
            casefiles ob = new casefiles();
            ob.dt = sql.GetData("select * from uploads where caseid='" + id + "'");
           
            return View(ob);
        }

      

        public FileResult Downloadfile(int id)
        {

            casefiles ob = new casefiles();
            ob.dt = sql.GetData("select * from uploads where upid='" + id + "'");
            string path = ob.dt.Rows[0]["path"].ToString();



            string CurrentFileName = path;

            string contentType = string.Empty;
            contentType = "application/pdf";  
            return File(CurrentFileName,contentType,  CurrentFileName);
        }  

// regiseer case===============================================================================
//=========notif==============================================================================

        public ActionResult notifs()
        {
            notif ob = new notif();
            ob.dt = sql.GetData("select * from notifications where clid='" + Session["cid"].ToString() + "' order by NotId desc");
            return View(ob);
        }
//=========notif==============================================================================

// communicate===================================================================
        public ActionResult getadv()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where clientid='" + Session["cid"].ToString() + "' and  status='Accepted'");

            return View(ob);
        }

        public ActionResult sendmessage(int id)
        {
            communi ob = new communi();
            ob.dt=sql.GetData("select * from Cases where caseid='"+id+"'");
            ob.caseid = id.ToString();
            return View(ob);
        }

        public ActionResult msgins(communi ob)
        {
            int c = sql.Execute("insert into communicate values('" + ob.caseid + "','" + System.DateTime.Now.ToString() + "','" + Session["Cname"].ToString() + "','" + ob.message + "')");
            return RedirectToAction("getadv", "Client");
        }
        public ActionResult viewmessage(int id)
        {
            communi ob = new communi();
            
            ob.dt = sql.GetData("select * from communicate where caseid='" + id + "' order by timestamp desc ");
            ob.caseid = id.ToString();
            return View(ob);
        }

// communicate===================================================================

// Book Appointment===================================================================
        public ActionResult getadvappointment()
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

        public ActionResult bookappoint(int id)
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("SELECT * FROM Advocates where Advid='" + id + "'");
            ob.did = ob.dt.Rows[0]["Advid"].ToString();
            ob.dname = ob.dt.Rows[0]["name"].ToString();
            
         
            return View(ob);
        }

        public ActionResult insappoi(uppointments ob)
        {
            int c = sql.Execute("insert into Appointments values('" + Session["cid"].ToString() + "','" + Session["Cname"].ToString() + "','" + ob.did + "','" + ob.dname + "','" + ob.dateshow + "','" + ob.dateshow + "','" + ob.descri + "','Pending')");
            return RedirectToAction("viewappoi", "Client");
        }

        public ActionResult viewappoi()
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("select * from Appointments where pid='" + Session["cid"].ToString() + "'");
            return View(ob);
        }
 // Book Appointment===================================================================


        public ActionResult casehist(int id)
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where advid='" + id + "' and status='Closesd'");
            return View(ob);
        }
    }
}
