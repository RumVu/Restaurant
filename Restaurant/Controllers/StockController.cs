using Dblayer;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class StockController : Controller
        
    {
        RemyDbEntities db = new RemyDbEntities();
        // StockItemCategory > ADD , EDIT
        public ActionResult StockItemCategory(int ? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index","Home");
            }
            var stockcategories = new CRU_StockItemCategoryMV(id);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(),"VisibleStatusID", "VisibleStatus",stockcategories.VisibleStatusID);
            return View(stockcategories);
        }

        [HttpPost]
        public ActionResult StockItemCategory(CRU_StockItemCategoryMV stockcategory)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]),out userid);
            stockcategory.CreatedBy_UserID = userid;
            if (ModelState.IsValid) 
            {
                if (stockcategory.StockItemCategoryID == 0)
                {
                    var checkexist = db.StockItemCategoryTables.Where(s => s.StockItemCategory.Trim().ToUpper() == stockcategory.StockItemCategory.Trim().ToUpper()).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newcategory = new StockItemCategoryTable();
                        newcategory.StockItemCategory = stockcategory.StockItemCategory;
                        newcategory.VisibleStatusID = stockcategory.VisibleStatusID;
                        newcategory.CreatedBy_UserID=userid;
                        db.StockItemCategoryTables.Add(newcategory);
                        db.SaveChanges();
                        return RedirectToAction("StockItemCategory", new {id = 0});
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemCategory", "Already Registered");
                    }
                }
                else 
                {
                    var  checkexist = db.StockItemCategoryTables.Where(
                        s => s.StockItemCategory.Trim().ToUpper() == stockcategory.StockItemCategory.Trim().ToUpper() 
                        && s.StockItemCategoryID != stockcategory.StockItemCategoryID ).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var editcategory = db.StockItemCategoryTables.Find(stockcategory.StockItemCategoryID );
                        editcategory.StockItemCategory = stockcategory.StockItemCategory;
                        editcategory.VisibleStatusID = stockcategory.VisibleStatusID;
                        editcategory.CreatedBy_UserID = userid;
                        db.Entry(editcategory).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("StockItemCategory", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemCategory", "Already Registered");
                    }
                }
            }
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", stockcategory.VisibleStatusID);
            return View(stockcategory);
        }
        
        
        // OrderType > ADD , EDIT
        public ActionResult OrderType(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var ordertype = new CRU_OrderTypeMV(id);
            
            return View(ordertype); 
        
        }

        [HttpPost]
        public ActionResult OrderType(CRU_OrderTypeMV cRU_OrderTypeMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if (cRU_OrderTypeMV.OrderTypeID == 0) 
                {
                    var checkexist = db.OrderTypeTables.Where(s => s.OrderType.Trim().ToUpper() == cRU_OrderTypeMV.OrderType.Trim().ToUpper()).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var neworder = new OrderTypeTable();
                        neworder.OrderType = cRU_OrderTypeMV.OrderType;
                        db.OrderTypeTables.Add(neworder);
                        db.SaveChanges();
                        return RedirectToAction("OrderType", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("OrderType", "Already Registered");
                    }
                }
                else
                {
                    var checkexist = db.OrderTypeTables.Where(s => s.OrderType.Trim().ToUpper() 
                    == cRU_OrderTypeMV.OrderType.Trim().ToUpper()
                    && s.OrderTypeID != cRU_OrderTypeMV.OrderTypeID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var editorder = db.OrderTypeTables.Find(cRU_OrderTypeMV.OrderTypeID);
                        editorder.OrderType = cRU_OrderTypeMV.OrderType;
                        db.Entry(editorder).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("OrderType", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("OrderType", "Already Registered");
                    }
                }
            }  

            return View(cRU_OrderTypeMV);
        }

        // StockMenuCategory > ADD , EDIT
        public ActionResult StockMenuCategory(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var menucategories = new CRU_StockMenuCategoryMV(id);
           
            return View(menucategories);
        }
        [HttpPost]
        public ActionResult StockMenuCategory(CRU_StockMenuCategoryMV cRU_StockMenuCategoryMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            cRU_StockMenuCategoryMV.CreatedBy_UserID = userid;
            if (ModelState.IsValid)
            {
                if (cRU_StockMenuCategoryMV.StockMenuCategoryID == 0)
                {
                    var checkexist = db.StockMenuCategoryTables.Where(s => s.StockMenuCategory.Trim().ToUpper() == cRU_StockMenuCategoryMV.StockMenuCategory.Trim().ToUpper()).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newcategory = new StockMenuCategoryTable();
                        newcategory.StockMenuCategory = cRU_StockMenuCategoryMV.StockMenuCategory;
                        newcategory.CreatedBy_UserID = userid;
                        db.StockMenuCategoryTables.Add(newcategory);
                        db.SaveChanges();
                        return RedirectToAction("StockMenuCategory", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockMenuCategory", "Already Registered");
                    }
                }
                else
                {
                    var checkexist = db.StockMenuCategoryTables.Where(
                        s => s.StockMenuCategory.Trim().ToUpper() == cRU_StockMenuCategoryMV.StockMenuCategory.Trim().ToUpper()
                        && s.StockMenuCategoryID != cRU_StockMenuCategoryMV.StockMenuCategoryID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var editcategory = db.StockMenuCategoryTables.Find(cRU_StockMenuCategoryMV.StockMenuCategoryID);
                        editcategory.StockMenuCategory = cRU_StockMenuCategoryMV.StockMenuCategory;
                        editcategory.CreatedBy_UserID = userid;
                        db.Entry(editcategory).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("StockMenuCategory", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockMenuCategory", "Already Registered");
                    }
                }
            }
            return View(cRU_StockMenuCategoryMV);
        }

        // StockItem > ADD , EDIT
        public ActionResult StockItem(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var stockitem = new CRU_StockItemMV(id);
            ViewBag.StockItemCategoryID = new SelectList(db.StockItemCategoryTables.ToList(), "StockItemCategoryID", "StockItemCategory", stockitem.StockItemCategoryID);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", stockitem.VisibleStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypeTables.ToList(), "OrderTypeID", "OrderType", stockitem.OrderTypeID);
            return View(stockitem);
        }
        [HttpPost]
        public ActionResult StockItem(CRU_StockItemMV cru_StockItemMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }

            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            cru_StockItemMV.CreatedBy_UserID = userid;
            cru_StockItemMV.RegisterDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (cru_StockItemMV.StockItemID == 0)
                {
                    var checkexist = db.StockItemTables.Where(
                        s=> s.StockItemTitle.Trim().ToUpper() == cru_StockItemMV.StockItemTitle.Trim()
                        && s.StockItemCategoryID == cru_StockItemMV.StockItemCategoryID
                        && s.OrderTypeID == cru_StockItemMV.OrderTypeID
                        && s.ItemSize == cru_StockItemMV.ItemSize).FirstOrDefault();
                    if(checkexist == null)
                    {
                        var newitem = new StockItemTable();
                        newitem.StockItemCategoryID = cru_StockItemMV.StockItemCategoryID;
                        newitem.ItemPhotoPath = @"~/Content/StockItemPhoto/default.png";
                        newitem.StockItemTitle = cru_StockItemMV.StockItemTitle;
                        newitem.ItemSize = cru_StockItemMV.ItemSize;
                        newitem.UnitPrice = cru_StockItemMV.UnitPrice;
                        newitem.VisibleStatusID = cru_StockItemMV.VisibleStatusID;
                        newitem.OrderTypeID = cru_StockItemMV.OrderTypeID;
                        newitem.CreatedBy_UserID = cru_StockItemMV.CreatedBy_UserID;
                        newitem.RegisterDate = DateTime.Now;
                        db.StockItemTables.Add(newitem);
                        db.SaveChanges();

                        if (cru_StockItemMV.PhotoPath != null)
                        {
                            var folder = "~/Content/ProfilePhoto";
                            var photoname = string.Format("{0}.jpg", newitem.StockItemID);
                            var response = HelperClass.FileUpload.UploadPhoto(cru_StockItemMV.PhotoPath, folder, photoname);
                            if (response)
                            {
                                var photo = string.Format("{0}/{1}", folder, photoname);
                                newitem.ItemPhotoPath = photo;
                                db.Entry(newitem).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("StockItem",new {id = 0});
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemTitle", "Already Exists");
                    }
                        
                }
                else
                {
                    var checkexist = db.StockItemTables.Where(
                        s => s.StockItemTitle.Trim().ToUpper() == cru_StockItemMV.StockItemTitle.Trim()
                        && s.StockItemCategoryID == cru_StockItemMV.StockItemCategoryID
                        && s.OrderTypeID == cru_StockItemMV.OrderTypeID
                        && s.ItemSize == cru_StockItemMV.ItemSize
                        && s.StockItemID != cru_StockItemMV.StockItemID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var edititem = db.StockItemTables.Find(cru_StockItemMV.StockItemID);
                        edititem.StockItemCategoryID = cru_StockItemMV.StockItemCategoryID;
                        edititem.StockItemTitle = cru_StockItemMV.StockItemTitle;
                        edititem.ItemSize = cru_StockItemMV.ItemSize;
                        edititem.UnitPrice = cru_StockItemMV.UnitPrice;
                        edititem.VisibleStatusID = cru_StockItemMV.VisibleStatusID;
                        edititem.OrderTypeID = cru_StockItemMV.OrderTypeID;
                        db.Entry(edititem).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        if (cru_StockItemMV.PhotoPath != null)
                        {
                            var folder = "~/Content/ProfilePhoto";
                            var photoname = string.Format("{0}.jpg", edititem.StockItemID);
                            var response = HelperClass.FileUpload.UploadPhoto(cru_StockItemMV.PhotoPath, folder, photoname);
                            if (response)
                            {
                                var photo = string.Format("{0}/{1}", folder, photoname);
                                edititem.ItemPhotoPath = photo;
                                db.Entry(edititem).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("StockItem", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemTitle", "Already Exists");
                    }
                }
            }

            ViewBag.StockItemCategoryID = new SelectList(db.StockItemCategoryTables.ToList(), "StockItemCategoryID", "StockItemCategory", cru_StockItemMV.StockItemCategoryID);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", cru_StockItemMV.VisibleStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypeTables.ToList(), "OrderTypeID", "OrderType", cru_StockItemMV.OrderTypeID);
            return View(cru_StockItemMV);
        }

        //StockMenu > ADD , EDIT
        public ActionResult StockMenu(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var stockmenuitem = new CRU_StockMenuItemMV(id);
            ViewBag.StockMenuCategoryID = new SelectList(db.StockMenuCategoryTables.ToList(), "StockMenuCategoryID", "StockMenuCategory", stockmenuitem.StockMenuCategoryID);
            ViewBag.StockItemID = new SelectList(db.StockItemTables.ToList(), "StockItemID", "StockItemTitle", stockmenuitem.StockItemID);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", stockmenuitem.VisibleStatusID);
            return View(stockmenuitem);
        }

        [HttpPost]
        public ActionResult StockMenu(CRU_StockMenuItemMV cru_StockMenuItemMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            if (ModelState.IsValid)
            {
                if (cru_StockMenuItemMV.StockMenuItemID == 0)
                {
                    var checkexist = db.StockMenuItemTables.Where(
                        s => s.StockMenuCategoryID == cru_StockMenuItemMV.StockMenuCategoryID
                        && s.StockItemID == cru_StockMenuItemMV.StockItemID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newitem = new StockMenuItemTable();
                        newitem.StockMenuCategoryID = cru_StockMenuItemMV.StockMenuCategoryID;
                        newitem.StockItemID = cru_StockMenuItemMV.StockItemID;
                        newitem.VisibleStatusID = cru_StockMenuItemMV.VisibleStatusID;
                        newitem.CreatedBy_UserID = userid;
                        db.StockMenuItemTables.Add(newitem);
                        db.SaveChanges();
                        return RedirectToAction("StockMenu", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemID", "Already Exist!");
                    }
                }
                else
                {
                    var checkexist = db.StockMenuItemTables.Where(
                        s => s.StockMenuCategoryID == cru_StockMenuItemMV.StockMenuCategoryID
                        && s.StockItemID == cru_StockMenuItemMV.StockItemID
                        && s.StockMenuItemID != cru_StockMenuItemMV.StockMenuItemID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var edititem = db.StockMenuItemTables.Find(cru_StockMenuItemMV.StockMenuItemID);
                        edititem.StockMenuCategoryID = cru_StockMenuItemMV.StockMenuCategoryID;
                        edititem.StockItemID = cru_StockMenuItemMV.StockItemID;
                        edititem.VisibleStatusID = cru_StockMenuItemMV.VisibleStatusID;
                        edititem.CreatedBy_UserID = userid;
                        db.Entry(edititem).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("StockMenu", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemID", "Already Exist!");
                    }
                }
            }
            ViewBag.StockMenuCategoryID = new SelectList(db.StockMenuCategoryTables.ToList(), "StockMenuCategoryID", "StockMenuCategory", cru_StockMenuItemMV.StockMenuCategoryID);
            ViewBag.StockItemID = new SelectList(db.StockItemTables.ToList(), "StockItemID", "StockItemTitle", cru_StockMenuItemMV.StockItemID);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", cru_StockMenuItemMV.VisibleStatusID);
            return View(cru_StockMenuItemMV);
        }

        //StockItemIngredient > ADD , EDIT
        public ActionResult StockItemIngredient(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var list = new CRU_StockItemIngredientMV(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult StockItemIngredient(CRU_StockItemIngredientMV cRU_StockItemIngredientMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);

            if (ModelState.IsValid)
            {
                if (cRU_StockItemIngredientMV.StockItemID > 0)
                {
                    var checkexist = db.StockItemIngredientTables.Where(
                        s => s.StockItemIngredientTitle.Trim().ToUpper() == cRU_StockItemIngredientMV.StockItemIngredientTitle.Trim().ToUpper()
                        && s.StockItemID == cRU_StockItemIngredientMV.StockItemID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newingredient = new StockItemIngredientTable();
                        newingredient.StockItemID = cRU_StockItemIngredientMV.StockItemID;
                        newingredient.StockItemIngredientPhotoPath = @"~/Content/StockIngredientPhoto/default.png";
                        newingredient.StockItemIngredientTitle = cRU_StockItemIngredientMV.StockItemIngredientTitle;
                        newingredient.CreatedBy_UserID = userid;
                        db.StockItemIngredientTables.Add(newingredient);
                        db.SaveChanges();
                        if (cRU_StockItemIngredientMV.PhotoPath != null)
                        {
                            var folder = "~/Content/StockIngredientPhoto";
                            var photoname = string.Format("{0}.jpg", newingredient.StockItemIngredientID);
                            var response = HelperClass.FileUpload.UploadPhoto(cRU_StockItemIngredientMV.PhotoPath, folder, photoname);
                            if (response)
                            {
                                var photo = string.Format("{0}/{1}", folder, photoname);
                                newingredient.StockItemIngredientPhotoPath = photo;
                                db.Entry(newingredient).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("StockItemIngredient", new { id = cRU_StockItemIngredientMV.StockItemID });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemIngredientTitle", "Already Exist!");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Close and Select Item First!");
                }
            }
            var list = new CRU_StockItemIngredientMV(cRU_StockItemIngredientMV.StockItemID);
            list.StockItemIngredientTitle = cRU_StockItemIngredientMV.StockItemIngredientTitle;
            list.StockItemID = cRU_StockItemIngredientMV.StockItemID;
            list.PhotoPath = cRU_StockItemIngredientMV.PhotoPath;
            return View(list);
        }

        //DeleteIngredient 
        public ActionResult DeleteIngredient(int? id)
        {
            var ingredient = db.StockItemIngredientTables.Find(id);
            db.Entry(ingredient).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("StockItemIngredient", new { id = ingredient.StockItemID });
        }


        //StockDeal  > create and edit
        [HttpGet]
        public ActionResult StockDeal(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var stockdeals = new CRU_StockDealMV(id);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", stockdeals.VisibleStatusID);
            return View(stockdeals);
        }

        [HttpPost]
        public ActionResult StockDeal(CRU_StockDealMV cru_StockDealMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            if (ModelState.IsValid)
            {
                if (cru_StockDealMV.StockDealID == 0)
                {
                    var checkexist = db.StockDealTables.Where(
                        s => s.StockDealTitle == cru_StockDealMV.StockDealTitle).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newdeal = new StockDealTable();
                        newdeal.StockDealTitle = cru_StockDealMV.StockDealTitle;
                        newdeal.DealPrice = cru_StockDealMV.DealPrice;
                        newdeal.VisibleStatusID = cru_StockDealMV.VisibleStatusID;
                        newdeal.StockDealStartDate = cru_StockDealMV.StockDealStartDate;
                        newdeal.Discount = cru_StockDealMV.Discount;
                        newdeal.StockDealEndDate = cru_StockDealMV.StockDealEndDate;
                        newdeal.StockDealRegisterDate = cru_StockDealMV.StockDealRegisterDate;
                        db.StockDealTables.Add(newdeal);
                        db.SaveChanges();
                        if (cru_StockDealMV.PhotoPath != null)
                        {
                            var folder = "~/Content/Deals";
                            var photoname = string.Format("{0}.jpg", newdeal.StockDealID);
                            var response = HelperClass.FileUpload.UploadPhoto(cru_StockDealMV.PhotoPath, folder, photoname);
                            if (response)
                            {
                                var photo = string.Format("{0}/{1}", folder, photoname);
                                newdeal.DealPhoto = photo;
                                db.Entry(newdeal).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("StockDeal", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockDealTitle", "Already Exist!");
                    }
                }
                else
                {
                    var checkexist = db.StockDealTables.Where(
                        s => s.StockDealTitle == cru_StockDealMV.StockDealTitle
                        && s.StockDealID != cru_StockDealMV.StockDealID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var editdeal = db.StockDealTables.Find(cru_StockDealMV.StockDealID);
                        editdeal.StockDealTitle = cru_StockDealMV.StockDealTitle;
                        editdeal.DealPrice = cru_StockDealMV.DealPrice;
                        editdeal.VisibleStatusID = cru_StockDealMV.VisibleStatusID;
                        editdeal.StockDealStartDate = cru_StockDealMV.StockDealStartDate;
                        editdeal.Discount = cru_StockDealMV.Discount;
                        editdeal.StockDealEndDate = cru_StockDealMV.StockDealEndDate;
                        editdeal.StockDealRegisterDate = cru_StockDealMV.StockDealRegisterDate;
                        db.Entry(editdeal).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        if (cru_StockDealMV.PhotoPath != null)
                        {
                            var folder = "~/Content/Deals";
                            var photoname = string.Format("{0}.jpg", editdeal.StockDealID);
                            var response = HelperClass.FileUpload.UploadPhoto(cru_StockDealMV.PhotoPath, folder, photoname);
                            if (response)
                            {
                                var photo = string.Format("{0}/{1}", folder, photoname);
                                editdeal.DealPhoto = photo;
                                db.Entry(editdeal).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("StockDeal", new { id = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockDealTitle", "Already Exist!");
                    }
                }
            }
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", cru_StockDealMV.VisibleStatusID);
            return View(cru_StockDealMV);
        }

        /// <summary>
        /// StockDealItem
        /// </summary>
        /// <param name="dealid"></param>
        /// <param name="stockdealdetailid"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StockDealItem(int dealid, int stockdealdetailid)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            var stockdealdetails = new CRU_StockDealDetailMV(dealid, stockdealdetailid);
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", stockdealdetails.VisibleStatusID);
            ViewBag.StockItemID = new SelectList(db.StockItemTables.ToList(), "StockItemID", "StockItemTitle", stockdealdetails.StockItemID);
            return View(stockdealdetails);
        }

        [HttpPost]
        public ActionResult StockDealItem(CRU_StockDealDetailMV cru_StockDealDetailMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            if (ModelState.IsValid)
            {
                if (cru_StockDealDetailMV.StockDealDetailID == 0)
                {
                    var checkexist = db.StockDealDetailTables.Where(
                        s => s.StockItemID == cru_StockDealDetailMV.StockItemID
                        && s.VisibleStatusID == 1
                        && s.StockDealID == cru_StockDealDetailMV.StockItemID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var newitem = new StockDealDetailTable();
                        newitem.StockDealID = cru_StockDealDetailMV.StockDealID;
                        newitem.StockItemID = cru_StockDealDetailMV.StockItemID;
                        newitem.Discount = cru_StockDealDetailMV.Discount;
                        newitem.Quantity = cru_StockDealDetailMV.Quantity;
                        newitem.VisibleStatusID = cru_StockDealDetailMV.VisibleStatusID;
                        db.StockDealDetailTables.Add(newitem);
                        db.SaveChanges();
                        return RedirectToAction("StockDealItem", new { dealid = cru_StockDealDetailMV.StockDealID, stockdealdetailid = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemID", "Already Exist!");
                    }
                }
                else
                {
                    var checkexist = db.StockDealDetailTables.Where(
                       s => s.StockItemID == cru_StockDealDetailMV.StockItemID
                       && s.VisibleStatusID == 1
                       && s.StockDealDetailID != cru_StockDealDetailMV.StockDealDetailID
                       && s.StockDealID == cru_StockDealDetailMV.StockItemID).FirstOrDefault();
                    if (checkexist == null)
                    {
                        var edititem = db.StockDealDetailTables.Find(cru_StockDealDetailMV.StockDealDetailID);
                        edititem.StockDealID = cru_StockDealDetailMV.StockDealID;
                        edititem.StockItemID = cru_StockDealDetailMV.StockItemID;
                        edititem.Discount = cru_StockDealDetailMV.Discount;
                        edititem.Quantity = cru_StockDealDetailMV.Quantity;
                        edititem.VisibleStatusID = cru_StockDealDetailMV.VisibleStatusID;
                        db.Entry(edititem).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("StockDealItem", new { dealid = cru_StockDealDetailMV.StockDealID, stockdealdetailid = 0 });
                    }
                    else
                    {
                        ModelState.AddModelError("StockItemID", "Already Exist!");
                    }
                }
            }
            ViewBag.VisibleStatusID = new SelectList(db.VisibleStatusTables.ToList(), "VisibleStatusID", "VisibleStatus", cru_StockDealDetailMV.VisibleStatusID);
            ViewBag.StockItemID = new SelectList(db.StockItemTables.ToList(), "StockItemID", "StockItemTitle", cru_StockDealDetailMV.StockItemID);
            return View(cru_StockDealDetailMV);
        }

    }
}