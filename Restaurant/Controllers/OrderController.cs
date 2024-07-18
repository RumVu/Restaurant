using Dblayer;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        RemyDbEntities db = new RemyDbEntities();
        public ActionResult Cart_AddItem(int? itemid, int? qty, string itemtype, string return_url)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var cart = db.CartTables.Where(u => u.UserID == userid).FirstOrDefault();
                    if (cart == null)
                    {
                        var create_cart = new CartTable()
                        {
                            UserID = userid
                        };
                        db.CartTables.Add(create_cart);
                        db.SaveChanges();
                        cart = db.CartTables.Where(u => u.UserID == userid).FirstOrDefault();
                    }

                    if (itemtype == "item")
                    {
                        var item = db.CartItemDetailTables.Where(i => i.StockItemID == itemid && i.CartID == cart.CartID).FirstOrDefault();
                        if (item != null)
                        {
                            item.Qty = item.Qty + 1;
                            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            var create_item = new CartItemDetailTable()
                            {
                                CartID = cart.CartID,
                                StockItemID = Convert.ToInt32(itemid),
                                Qty = Convert.ToInt32(qty)
                            };
                            db.CartItemDetailTables.Add(create_item);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var deal = db.CartDealTables.Where(d => d.StockDealID == itemid && d.CartID == cart.CartID).FirstOrDefault();
                        if (deal != null)
                        {
                            deal.Qty = deal.Qty + 1;
                            db.Entry(deal).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            var create_deal = new CartDealTable()
                            {
                                CartID = cart.CartID,
                                Qty = Convert.ToInt32(qty),
                                StockDealID = Convert.ToInt32(itemid)
                            };
                            db.CartDealTables.Add(create_deal);
                            db.SaveChanges();
                        }
                    }
                    result = true;
                    transaction.Commit();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    result = false;
                    transaction.Rollback();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult ViewCart()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Login", "User");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);

            var cart = db.CartTables.Where(u => u.UserID == userid).FirstOrDefault();
            var shoppingcart = new ShoppingCartMV(userid);
            var user = db.UserTables.Find(userid);

            int cartid = (cart != null ? cart.CartID : 0);
            foreach (var cart_item in db.CartItemDetailTables.Where(i => i.CartID == cartid).ToList())
            {
                var stockitem = db.StockItemTables.Find(cart_item.StockItemID);
                shoppingcart.Cart_Items.Add(new CartMV()
                {
                    CartID = cart.CartID,
                    CartItemID = cart_item.CartItemID,
                    StockItemID = cart_item.StockItemID,
                    StockItemTitle = stockitem.StockItemTitle,
                    StockItemCategory = stockitem.StockItemCategoryTable.StockItemCategory,
                    ItemPhotoPath = stockitem.ItemPhotoPath,
                    ItemSize = stockitem.ItemSize,
                    UnitPrice = stockitem.UnitPrice,
                    Qty = cart_item.Qty,
                    ItemCost = stockitem.UnitPrice * cart_item.Qty,
                    ItemType = "item"
                });
            }

            foreach (var cart_deal in db.CartDealTables.Where(d => d.CartID == cartid).ToList())
            {
                var stockdeal = db.StockDealTables.Find(cart_deal.StockDealID);
                shoppingcart.Cart_Items.Add(new CartMV()
                {
                    CartID = cart.CartID,
                    CartItemID = cart_deal.CartDealID,
                    StockItemID = cart_deal.StockDealID,
                    StockItemTitle = stockdeal.StockDealTitle,
                    StockItemCategory = "Deal",
                    ItemPhotoPath = stockdeal.DealPhoto,
                    ItemSize = "Normal",
                    UnitPrice = stockdeal.DealPrice,
                    Qty = cart_deal.Qty,
                    ItemCost = stockdeal.DealPrice * cart_deal.Qty,
                    ItemType = "Deal"
                });
            }

            ViewBag.UserAddressID = new SelectList(db.UserAddressTables.Where(ua => ua.UserID == userid).ToList(), "UserAddressID", "FullAddress", "0");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypeTables.ToList(), "OrderTypeID", "OrderType", "1");

            return View(shoppingcart);
        }

        public ActionResult Add_Qty(int? cartitemid, int? qty, string itemtype)
        {
            bool result = false;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (itemtype == "item")
                    {
                        var item = db.CartItemDetailTables.Where(i => i.CartItemID == cartitemid).FirstOrDefault();
                        if (item != null)
                        {
                            item.Qty = item.Qty + 1;
                            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var deal = db.CartDealTables.Where(d => d.CartDealID == cartitemid).FirstOrDefault();
                        if (deal != null)
                        {
                            deal.Qty = deal.Qty + 1;
                            db.Entry(deal).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    result = true;
                    transaction.Commit();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    result = false;
                    transaction.Rollback();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult Minus_Qty(int? cartitemid, int? qty, string itemtype)
        {
            bool result = false;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (itemtype == "item")
                    {
                        var item = db.CartItemDetailTables.Where(i => i.CartItemID == cartitemid).FirstOrDefault();
                        if (item != null)
                        {
                            if (item.Qty == 1)
                            {
                                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                                db.SaveChanges();
                            }
                            else
                            {
                                item.Qty = item.Qty - 1;
                                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        var deal = db.CartDealTables.Where(d => d.CartDealID == cartitemid).FirstOrDefault();
                        if (deal != null)
                        {
                            if (deal.Qty == 1)
                            {
                                db.Entry(deal).State = System.Data.Entity.EntityState.Deleted;
                                db.SaveChanges();
                            }
                            else
                            {
                                deal.Qty = deal.Qty - 1;
                                db.Entry(deal).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                    result = true;
                    transaction.Commit();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    result = false;
                    transaction.Rollback();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult Delete_Item(int? cartitemid,string itemtype)
        {
            bool result = false;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (itemtype == "item")
                    {
                        var item = db.CartItemDetailTables.Where(i => i.CartItemID == cartitemid).FirstOrDefault();
                        if (item != null)
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var deal = db.CartDealTables.Where(d => d.CartDealID == cartitemid).FirstOrDefault();
                        if (deal != null)
                        {
                            db.Entry(deal).State = System.Data.Entity.EntityState.Detached;
                            db.SaveChanges();
                        }
                    }
                    result = true;
                    transaction.Commit();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    result = false;
                    transaction.Rollback();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}