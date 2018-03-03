using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SodetsoUsersManagement.Services;
using SodetsoUsersManagement.Models;
using System.Net;

namespace SodetsoUsersManagement.Controllers
{
    public class UsersManagementController : Controller
    {
        //
        // GET: /UsersManagement/
        UsersManagementService _UsersManagementService = new UsersManagementService();
        SystemTools _SystemTools = new SystemTools();

        public ActionResult AddUser()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddUser";
                AddUserModel _AddUserModel = new AddUserModel();
                _AddUserModel.sex = _SystemTools.GetGender();
                return View(_AddUserModel);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            
        }

        [HttpPost]
        public JsonResult IsUserExists(string Email)
        {
            return Json(CheckUserEmail(Email));
        }

        public bool CheckUserEmail(string Email)
        {
            var result = _UsersManagementService.UsersList().Find(Rdr => Rdr.Email == Email);

            bool status;

            if (result != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;
        }

        [HttpPost]
        public ActionResult CreateUser(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    HttpPostedFileBase file = Request.Files["ImageData"];
                    _UsersManagementService.CreateUser(file, model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("AddUser");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("AddUser", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("AddUser");
            }

        }

        public ActionResult UsersList()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "UsersList";
                return View(_UsersManagementService.UsersList().ToList()); // redirecting to all Users List
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult DeactivateActivateUser(UsersListModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    _UsersManagementService.DeactivateActivateUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("UsersList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("UsersList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("UsersList");
            }

        }

        public ActionResult ActiveUsers()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "ActiveUsers";
                return View(_UsersManagementService.ActiveUsersList().ToList()); // redirecting to all Activve Users List
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult ActiveUsersPageDeactivateUser(UsersListModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    _UsersManagementService.DeactivateActivateUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("ActiveUsers");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("ActiveUsers", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("ActiveUsers");
            }

        }

        public ActionResult InActiveUsers()
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "InActiveUsers";
                return View(_UsersManagementService.InActiveUsersList().ToList()); // redirecting to all InActive Users List
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult InActiveUsersPageActivateUser(UsersListModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _UsersManagementService.DeactivateActivateUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("InActiveUsers");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("InActiveUsers", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("InActiveUsers");
            }

        }

        [HttpPost]
        public ActionResult RemoveUser(UsersListModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _UsersManagementService.RemoveUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("UsersList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("UsersList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("UsersList");
            }

        }

        public ActionResult ArchivedUsers()
        {
            return View(_UsersManagementService.ArchivedUsersList().ToList()); // redirecting to all Removed Users List
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            if (Session["Email"] != null && Session["UserID"] != null)
            {
                ViewBag.ActiveMenu = "AddUser";
                EditUserModel _EditUserModel = _UsersManagementService.ViewUserDetailsList().Find(uid => uid.UserID == id);
                _EditUserModel.sex = _SystemTools.GetGender();
                return View(_EditUserModel);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult UpdateUser(EditUserModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    HttpPostedFileBase file = Request.Files["ImageData"];
                    _UsersManagementService.UpdateUser(file, model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("UsersList");
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("", e.Message);
                    TempData["Fail"] = "Fail";
                    return View("UsersList", model);
                }
            }
            else
            {
                TempData["ModelsError"] = "Error";
                return RedirectToAction("UsersList");
            }

        }
    }
}
