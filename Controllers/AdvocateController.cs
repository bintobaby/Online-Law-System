using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBarcounsil.Models;

namespace MVCBarcounsil.Controllers
{
    public class AdvocateController : Controller
    {
        //
        // GET: /Advocate/

        common sql = new common();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult caseregs()
        {
            caseinfo ob = new caseinfo();

            ob.dt = sql.GetData("select * from Cases where advid='" + Session["Advid"].ToString() + "' and  status='Registred'");

            return View(ob);
         
        }

        public ActionResult acccase(int id)
        {
            caseinfo ob= new caseinfo();
            string msg = "Your Case Registration Accepted" + "\n" + "Case Id :" + id+ "\n" + "Advocate:" + Session["Aname"].ToString();
            int c = sql.Execute("update Cases set status ='Accepted' where caseid='" + id + "'");
            ob.dt = sql.GetData("select * from Cases where caseid='" + id + "'");
            string uname = ob.dt.Rows[0]["clientid"].ToString();
            int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");
            return RedirectToAction("caseregs", "Advocate");
        }
        public ActionResult rejcase(int id)
        {
            caseinfo ob = new caseinfo();
            string msg = "Your Case Registration Rejected" + "\n" + "Case Id :" + id + "\n" + "Advocate:" + Session["Aname"].ToString();
            int c = sql.Execute("update Cases set status ='Rejected' where caseid='" + id + "'");
            ob.dt = sql.GetData("select * from Cases where caseid='" + id + "'");
            string uname = ob.dt.Rows[0]["clientid"].ToString();
            int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");
            return RedirectToAction("caseregs", "Advocate");
        }

        public ActionResult caselist()
        {
            caseinfo ob = new caseinfo();

            ob.dt = sql.GetData("select * from Cases where advid='" + Session["Advid"].ToString() + "' and  status='Accepted'");

            return View(ob);

        }

        public ActionResult updatecase(int id)
        {
            caseupdates ob = new caseupdates();

            ob.dt=sql.GetData("select * from  Cases where caseid='"+id+"'");
            ob.caseid = id.ToString();
            return View(ob);
           
        }

        public ActionResult updatecasedetails(caseupdates ob)
        {
            int c = sql.Execute("insert into Updates values('" + ob.caseid + "','" + System.DateTime.Now.ToString() + "','" + ob.description + "')");
          
           

                string msg = "New Update " + "\n" + "Case Id :" + ob.caseid+ "\n" + "Advocate:" + Session["Aname"].ToString();
                ob.dt = sql.GetData("select * from Cases where caseid='" + ob.caseid + "'");
                string uname = ob.dt.Rows[0]["clientid"].ToString();
                int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");



                return RedirectToAction("caselist", "Advocate");
        }

        public ActionResult viewupdate(int id)
        {
            caseupdates ob = new caseupdates();

            ob.dt = sql.GetData("select * from  Updates where caseid='" + id + "' order by updid");
            ob.caseid = id.ToString();
            return View(ob);

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
            return File(CurrentFileName, contentType, CurrentFileName);
        }

        // communicate===================================================================
        public ActionResult getadv()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where advid='" + Session["Advid"].ToString() + "' and  status='Accepted'");

            return View(ob);
        }

        public ActionResult sendmessage(int id)
        {
            communi ob = new communi();
            ob.dt = sql.GetData("select * from Cases where caseid='" + id + "'");
            ob.caseid = id.ToString();
            return View(ob);
        }

        public ActionResult msgins(communi ob)
        {
            int c = sql.Execute("insert into communicate values('" + ob.caseid + "','" + System.DateTime.Now.ToString() + "','" + Session["Aname"].ToString() + "','" + ob.message + "')");
            return RedirectToAction("getadv", "Advocate");
        }
        public ActionResult viewmessage(int id)
        {
            communi ob = new communi();

            ob.dt = sql.GetData("select * from communicate where caseid='" + id + "' order by timestamp desc ");
            ob.caseid = id.ToString();
            return View(ob);
        }

        // communicate===================================================================


        // close===================================================================
        public ActionResult getcase()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where advid='" + Session["Advid"].ToString() + "' and  status='Accepted'");

            return View(ob);
        }

        public ActionResult closecase(int id)
        {
            caseinfo ob = new caseinfo();
            ob.caseid = id.ToString();
            return View(ob);
        }

        public ActionResult casecloseupdate(caseinfo ob)
        {
            int x = sql.Execute("update Cases set status='Closesd',cstatus='" + ob.casestst + "' where caseid='" + ob.caseid + "'");


            string msg = "You " + ob.casestst + " The Case " + "\n" + "Case Id :" + ob.caseid.ToString() + "\n" + "Advocate:" + Session["Aname"].ToString();
                ob.dt = sql.GetData("select * from Cases where caseid='" + ob.caseid + "'");
                string uname = ob.dt.Rows[0]["clientid"].ToString();
                int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");

                return RedirectToAction("getcase", "Advocate");
             
        }
        // close===================================================================
        // payment===================================================================
        public ActionResult getcaseclose()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where advid='" + Session["Advid"].ToString() + "' and status='Closesd' and feestatus=''");



            return View(ob);
        }

        public ActionResult uppayment(int id)
        {
              
               int x = sql.Execute("update Cases set feestatus='Paid' where caseid='" + id + "'");
             caseinfo ob= new caseinfo();
              ob.dt = sql.GetData("select * from Cases where caseid='" + id + "'");
                string uname = ob.dt.Rows[0]["clientid"].ToString();
                string msg = "Payment Recived " + "\n" + "Case Id :" + id.ToString() + "\n" + "Advocate:" + Session["Aname"].ToString();
                int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");
                return RedirectToAction("getcaseclose", "Advocate");
              
        }

        

        // payment===================================================================


        // appointments==============================================================
        public ActionResult pendingappintments()
        {
            uppointments ob = new uppointments();
            ob.dt=sql.GetData("select * from Appointments where status='Pending' and did='" + Session["Advid"].ToString() + "'");
            return View(ob);
        }

        public ActionResult acceptappoi(int id)
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("select * from Appointments where apoid='" + id + "'");
            string uname = ob.dt.Rows[0]["pid"].ToString();

            string msg = "Your Case Appointment Confirmed" + "\n" + "Appopinment  No :" + id.ToString() + "\n" + "Advocate:" + Session["Aname"].ToString();
            int c = sql.Execute("update Appointments set status ='Accepted' where apoid='" + id + "'");

            int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");
            return RedirectToAction("pendingappintments", "Advocate");
        }

        public ActionResult rejectappoi(int id)
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("select * from Appointments where apoid='" + id + "'");
            string uname = ob.dt.Rows[0]["pid"].ToString();

            string msg = "Your Case Appointment Rejected" + "\n" + "Appopinment  No :" + id.ToString() + "\n" + "Advocate:" + Session["Aname"].ToString();
            int c = sql.Execute("update Appointments set status ='Rejected' where apoid='" + id + "'");

            int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");
            return RedirectToAction("pendingappintments", "Advocate");
        }


        public ActionResult pendingappintments1()
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("select * from Appointments where status='Accepted' and did='" + Session["Advid"].ToString() + "'");
            return View(ob);
        }

        public ActionResult acceptappoi1(int id)
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("select * from Appointments where apoid='" + id + "'");
            string uname = ob.dt.Rows[0]["pid"].ToString();

            string msg = "Your Case Appointment Closed" + "\n" + "Appopinment  No :" + id.ToString() + "\n" + "Advocate:" + Session["Aname"].ToString();
            int c = sql.Execute("update Appointments set status ='Closed' where apoid='" + id + "'");

            int c1 = sql.Execute("insert into notifications values('" + uname + "','" + msg + "','" + System.DateTime.Now.ToString() + "')");
            return RedirectToAction("pendingappintments1", "Advocate");
        }

        public ActionResult completedappoi()
        {
            uppointments ob = new uppointments();
            ob.dt = sql.GetData("select * from Appointments where status='Closed' and did='" + Session["Advid"].ToString() + "'");
            return View(ob);
        }
       

        // appointments==============================================================


        //discussion============================================================================

        public ActionResult getdiss()
        {
            advinfo ob = new advinfo();
            ob.dt = sql.GetData("select * from Advocates where Advid<>'" + Session["Advid"].ToString() + "'");
            return View(ob);
        }

        public ActionResult sendiscuss(int id)
        {
            discinfo ob = new discinfo();
            ob.dt=sql.GetData("select * from Advocates where Advid='"+id+"'");
            string aname = ob.dt.Rows[0]["name"].ToString();
            ob.toid = id.ToString();
            ob.toname = aname;
            return View(ob);
          
                
        }

        public ActionResult discins(discinfo ob)
        {
            int c = sql.Execute("insert into discussion values('" + Session["Advid"].ToString() + "','" + Session["Aname"].ToString() + "','" + ob.toid + "','" + ob.toname + "','" + System.DateTime.Now.ToString() + "','" + ob.message + "')");
            return RedirectToAction("getdiss", "Advocate");
        }

        public ActionResult viewdiscuss(int id)
        {
            discinfo ob = new discinfo();
            ob.dt = sql.GetData("select  * from discussion where frid='" + Session["Advid"].ToString() + "' and  toid='" + id + "'  or  frid='" + id  + "' and toid='" + Session["Advid"].ToString() + "' ");
            return View(ob);
        }

        public ActionResult casehist()
        {
            caseinfo ob = new caseinfo();
            ob.dt = sql.GetData("select * from Cases where advid='" + Session["Advid"].ToString() + "' and status='Closesd'");
            return View(ob);
        }
        

    }
}
