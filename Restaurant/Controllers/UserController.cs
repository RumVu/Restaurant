using Dblayer;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        RemyDbEntities Db = new RemyDbEntities();
        // Login / Logout
        public ActionResult Login()
        {
            var user = new LoginMV();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(LoginMV loginMV)
        {

            if (ModelState.IsValid)
            {
                var user = Db.UserTables.Where(u => (u.EmailAddress==loginMV.UserName.Trim() || u.UserName.Trim() == loginMV.UserName.Trim()) && u.Password.Trim() == loginMV.Password.Trim()).FirstOrDefault();
                if (user != null)
                {
                    if (user.UserStatusID == 1)
                    {
                        Session["UserID"] = user.UserID;
                        Session["UserTypeID"] = user.UserTypeID;
                        return RedirectToAction("Dashboard", "User");
                    }
                    else
                    {
                        var accountstatus = Db.UserStatusTables.Find(user.UserStatusID);
                        ModelState.AddModelError(string.Empty, "Account is " + accountstatus.UserStatus + "");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please Enter Correct User Name and Password!");
                }
            }
            Session["UserID"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            return View(loginMV);
        }
        public ActionResult Logout()
        {
            Session["UserID"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            var user = new Reg_UserMV();
            ViewBag.GenderID = new SelectList(Db.GenderTables.ToList(), "GenderID", "GenderTitle", "0");
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(Reg_UserMV reg_UserMV)
        {
            reg_UserMV.UserTypeID = 4; // Customer User_Type_ID
            reg_UserMV.RegisterationDate = DateTime.Now;
            reg_UserMV.UserStatusID = 1;
            if (ModelState.IsValid)
            {
                bool isexist = false;
                var checkexist = Db.UserTables.Where(u => u.UserName.ToUpper().Trim() == reg_UserMV.UserName.ToUpper().Trim()).FirstOrDefault();
                if (checkexist != null)
                {
                    isexist = true;
                    ModelState.AddModelError("UserName", "Already Exist!");
                }
                checkexist = Db.UserTables.Where(u => u.EmailAddress.ToUpper().Trim() == reg_UserMV.EmailAddress.ToUpper().Trim()).FirstOrDefault();
                if (checkexist != null)
                {
                    isexist = true;
                    ModelState.AddModelError("EmailAddress", "Already Exist!");
                }
                if (isexist == false)
                {
                    var user = new UserTable();
                    user.UserTypeID = reg_UserMV.UserTypeID;
                    user.UserName = reg_UserMV.UserName;
                    user.Password = reg_UserMV.Password;
                    user.FirstName = reg_UserMV.FirstName;
                    user.LastName = reg_UserMV.LastName;
                    user.ContactNo = reg_UserMV.ContactNo;
                    user.GenderID = reg_UserMV.GenderID;
                    user.EmailAddress = reg_UserMV.EmailAddress;
                    user.RegisterationDate = reg_UserMV.RegisterationDate;
                    user.UserStatusID = reg_UserMV.UserStatusID;
                    Db.UserTables.Add(user);
                    Db.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
            }
            ViewBag.GenderID = new SelectList(Db.GenderTables.ToList(), "GenderID", "GenderTitle", reg_UserMV.GenderID);
            return View(reg_UserMV);
        }

        public ActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }

            int userid = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            }

            var dashboard = new DashboardMV(userid);
            return View(dashboard);
        }

        [HttpPost]
        public ActionResult Dashboard(DashboardMV dashboardMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Login", "User");
            }
            int userid = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            }
            var dasboard = new DashboardMV(userid);
            if (!string.IsNullOrEmpty(dashboardMV.OldPassword))
            {

                if (dasboard.ProfileMV.Password == dashboardMV.OldPassword)
                {
                    if (dashboardMV.NewPassword.Trim() == dashboardMV.ConfirmPassword.Trim())
                    {
                        var user = Db.UserTables.Find(userid);
                        user.Password = dashboardMV.NewPassword;
                        Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        ModelState.AddModelError("OldPassword", "Password Changed");
                    }
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Old Password is Incorrect!");
                }
            }
            if (!string.IsNullOrEmpty(dashboardMV.ProfileMV.FirstName) &&
               !string.IsNullOrEmpty(dashboardMV.ProfileMV.LastName) &&
               !string.IsNullOrEmpty(dashboardMV.ProfileMV.EmailAddress) &&
               !string.IsNullOrEmpty(dashboardMV.ProfileMV.ContactNo))
            {
                var user = Db.UserTables.Find(userid);
                user.FirstName = dashboardMV.ProfileMV.FirstName;
                user.LastName = dashboardMV.ProfileMV.LastName;
                user.EmailAddress = dashboardMV.ProfileMV.EmailAddress;
                user.ContactNo = dashboardMV.ProfileMV.ContactNo;
                Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                if (dashboardMV.ProfileMV.UserPhoto != null)
                {
                    var folder = "~/Content/ProfilePhoto";
                    var photoname = string.Format("{0}.jpg", user.UserID);
                    var response = HelperClass.FileUpload.UploadPhoto(dashboardMV.ProfileMV.UserPhoto, folder, photoname);
                    if (response)
                    {
                        var photo = string.Format("{0}/{1}", folder, photoname);
                        var userdetail = Db.UserDetailTables.Find(userid);
                        if (userdetail == null)
                        {
                            userdetail = new UserDetailTable();
                            userdetail.UserDetailID = userid;
                            userdetail.UserID = userid;
                            userdetail.CreatedBy_UserID = userid;
                            userdetail.UserDetailProviderDate = DateTime.Now;
                            userdetail.PhotoPath = photo;
                            Db.UserDetailTables.Add(userdetail);
                            Db.SaveChanges();
                        }
                        userdetail.PhotoPath = photo;
                        userdetail.UserDetailProviderDate = DateTime.Now;
                        Db.Entry(userdetail).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                    }
                }
                ModelState.AddModelError(string.Empty, "Updated");
            }
            return View(dasboard);
        }
    }
}