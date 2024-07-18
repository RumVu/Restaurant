using Dblayer;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class SettingController : Controller
    {
        RemyDbEntities Db = new RemyDbEntities();
        // UserTypes > ADD, EDIT
        public ActionResult List_UserTypes(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var usertype = new CRU_UserTypeMV(id);
            return View(usertype);
        }
        [HttpPost]
        public ActionResult List_UserTypes(CRU_UserTypeMV cRU_UserTypeMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if (cRU_UserTypeMV.UserTypeID == 0)
                {
                    var checkexist = Db.UserTypeTables.Where(u => u.UserType == cRU_UserTypeMV.UserType).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var usertype = new UserTypeTable();
                        usertype.UserType = cRU_UserTypeMV.UserType;
                        Db.UserTypeTables.Add(usertype);
                        Db.SaveChanges();
                        return RedirectToAction("List_UserTypes", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("UserType", "All Ready Exist!");
                    }
                }
                else
                {
                    var checkexist = Db.UserTypeTables.Where(u => u.UserType == cRU_UserTypeMV.UserType && u.UserTypeID != cRU_UserTypeMV.UserTypeID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var usertype = Db.UserTypeTables.Find(cRU_UserTypeMV.UserTypeID);
                        usertype.UserType = cRU_UserTypeMV.UserType;
                        Db.Entry(usertype).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        return RedirectToAction("List_UserTypes", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("UserType", "All Ready Exist!");
                    }
                }
            }
            return View(cRU_UserTypeMV);
        }

        // Gender > ADD, EDIT
        public ActionResult List_Genders(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var gender = new CRU_GenderMV(id);
            return View(gender);
        }
        [HttpPost]
        public ActionResult List_Genders(CRU_GenderMV cRU_GenderMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if (cRU_GenderMV.GenderID == 0)
                {
                    var checkexist = Db.GenderTables.Where(g => g.GenderTitle == cRU_GenderMV.GenderTitle).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var gender = new GenderTable();
                        gender.GenderTitle = cRU_GenderMV.GenderTitle;
                        Db.GenderTables.Add(gender);
                        Db.SaveChanges();
                        return RedirectToAction("List_Genders", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("GenderTitle", "All Ready Exist!");
                    }
                }
                else
                {
                    var checkexist = Db.GenderTables.Where(g => g.GenderTitle == cRU_GenderMV.GenderTitle && g.GenderID != cRU_GenderMV.GenderID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var editgender = Db.GenderTables.Find(cRU_GenderMV.GenderID);
                        editgender.GenderTitle = cRU_GenderMV.GenderTitle;
                        Db.Entry(editgender).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        return RedirectToAction("List_Genders", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("GenderTitle", "All Ready Exist!");
                    }
                }
            }
            return View(cRU_GenderMV);
        }

        // User Status> ADD , EDIT
        public ActionResult List_UserStatus(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var userstatus = new CRU_UserStatusMV(id);
            return View(userstatus);
        }

        [HttpPost]
        public ActionResult List_UserStatus(CRU_UserStatusMV cRU_UserStatusMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if (cRU_UserStatusMV.UserStatusID == 0)
                {
                    var checkexist = Db.UserStatusTables.Where(s => s.UserStatus.ToUpper() == cRU_UserStatusMV.UserStatus.ToUpper()).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var userstatus = new UserStatusTable();
                        userstatus.UserStatus = cRU_UserStatusMV.UserStatus;
                        Db.UserStatusTables.Add(userstatus);
                        Db.SaveChanges();
                        return RedirectToAction("List_UserStatus", new { id = 0 });

                    }
                    else
                    {
                        ModelState.AddModelError("UserStatus", "Field Required*");
                    }
                }
                else
                {
                    var checkexist = Db.UserStatusTables.Where(s => s.UserStatus.ToUpper() == cRU_UserStatusMV.UserStatus.ToUpper() && s.UserStatusID != cRU_UserStatusMV.UserStatusID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var userstatus = Db.UserStatusTables.Find(cRU_UserStatusMV.UserStatusID);
                        userstatus.UserStatus = cRU_UserStatusMV.UserStatus;
                        Db.Entry(userstatus).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        return RedirectToAction("List_UserStatus", new { id = 0 });

                    }
                    else
                    {
                        ModelState.AddModelError("UserStatus", "Field Required*");
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Fill All Field Properly.");
            }
            return View(cRU_UserStatusMV);
        }

        // User Status> ADD , EDIT
        public ActionResult List_VisibleStatus(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var status = new CRU_VisibleStatusMV(id);
            return View(status);
        }

        [HttpPost]
        public ActionResult List_VisibleStatus(CRU_VisibleStatusMV cRU_VisibleStatusMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if (cRU_VisibleStatusMV.VisibleStatusID == 0)
                {
                    var checkexist = Db.VisibleStatusTables.Where(s => s.VisibleStatus.ToUpper() == cRU_VisibleStatusMV.VisibleStatus.ToUpper()).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var status = new VisibleStatusTable();
                        status.VisibleStatus = cRU_VisibleStatusMV.VisibleStatus;
                        Db.VisibleStatusTables.Add(status);
                        Db.SaveChanges();
                        return RedirectToAction("List_VisibleStatus", new { id = 0 });

                    }
                    else
                    {
                        ModelState.AddModelError("VisibleStatus", "Field Required*");
                    }
                }
                else
                {
                    var checkexist = Db.VisibleStatusTables.Where(s => s.VisibleStatus.ToUpper() == cRU_VisibleStatusMV.VisibleStatus.ToUpper() && s.VisibleStatusID != cRU_VisibleStatusMV.VisibleStatusID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var editstatus = Db.VisibleStatusTables.Find(cRU_VisibleStatusMV.VisibleStatusID);
                        editstatus.VisibleStatus = cRU_VisibleStatusMV.VisibleStatus;
                        Db.Entry(editstatus).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        return RedirectToAction("List_VisibleStatus", new { id = 0 });

                    }
                    else
                    {
                        ModelState.AddModelError("VisibleStatus", "Field Required*");
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Fill All Field Properly.");
            }
            return View(cRU_VisibleStatusMV);
        }

        // User Address> ADD , EDIT
        public ActionResult List_UserAddress(int? id)
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
            var address = new CRU_UserAddressMV(id);
            ViewBag.AddressTypeID = new SelectList(Db.AddressTypeTables.ToList(), "AddressTypeID", "AddressType", address.AddressTypeID);
            ViewBag.VisibleStatusID = new SelectList(Db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", address.VisibleStatusID);
            return View(address);
        }

        [HttpPost]
        public ActionResult List_UserAddress(CRU_UserAddressMV cRU_UserAddressMV)
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
            if (ModelState.IsValid)
            {
                if (cRU_UserAddressMV.UserAddressID == 0)
                {
                    var checkexist = Db.UserAddressTables.Where(s => s.FullAddress.ToUpper() == cRU_UserAddressMV.FullAddress.ToUpper() && s.AddressTypeID == cRU_UserAddressMV.AddressTypeID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newaddress = new UserAddressTable();
                        newaddress.UserID = userid;
                        newaddress.AddressTypeID = cRU_UserAddressMV.AddressTypeID;
                        newaddress.FullAddress = cRU_UserAddressMV.FullAddress;
                        newaddress.VisibleStatusID = cRU_UserAddressMV.VisibleStatusID;
                        newaddress.CreatedBy_UserID = userid;
                        Db.UserAddressTables.Add(newaddress);
                        Db.SaveChanges();
                        return RedirectToAction("List_UserAddress", new { id = 0 });

                    }
                    else
                    {
                        ModelState.AddModelError("FullAddress", "Already Exist!");
                    }
                }
                else
                {
                    var checkexist = Db.UserAddressTables.Where(s => s.FullAddress.ToUpper() == cRU_UserAddressMV.FullAddress.ToUpper() && s.AddressTypeID == cRU_UserAddressMV.AddressTypeID && s.UserAddressID != cRU_UserAddressMV.UserAddressID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var edituseraddress = Db.UserAddressTables.Find(cRU_UserAddressMV.UserAddressID);
                        edituseraddress.UserID = userid;
                        edituseraddress.AddressTypeID = cRU_UserAddressMV.AddressTypeID;
                        edituseraddress.FullAddress = cRU_UserAddressMV.FullAddress;
                        edituseraddress.VisibleStatusID = cRU_UserAddressMV.VisibleStatusID;
                        edituseraddress.CreatedBy_UserID = userid;
                        Db.Entry(edituseraddress).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        return RedirectToAction("List_UserAddress", new { id = 0 });

                    }
                    else
                    {
                        ModelState.AddModelError("FullAddress", "Already Exist!");
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Fill All Field Properly.");
            }
            ViewBag.AddressTypeID = new SelectList(Db.AddressTypeTables.ToList(), "AddressTypeID", "AddressType", cRU_UserAddressMV.AddressTypeID);
            ViewBag.VisibleStatusID = new SelectList(Db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", cRU_UserAddressMV.VisibleStatusID);
            return View(cRU_UserAddressMV);
        }



    }
}