using Dblayer;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        RemyDbEntities db = new RemyDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            var home = new HomeMV();
            return View(home);
        }

        //Allitems
        public ActionResult AllItems()
        {
            var list = new StockMenuMV();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllItems(StockMenuMV stockMenuMV)
        {
            var list = new StockMenuMV(stockMenuMV.SearchKey, stockMenuMV.categorylist, stockMenuMV.ordertypelist);
            return View(list);
        }
        public ActionResult OurMenu()
        {
            var home = new HomeMV();
            return View(home);
        }

        public ActionResult ProductDetail(int? itemid)
        {
            if (itemid == null | itemid == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            var item_detail = new ItemDetailMV();
            item_detail.StockItemID = (int)itemid;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                int userid = 0;
                int.TryParse(Convert.ToString(Session["UserID"]), out userid);
                var userdetail = db.UserTables.Find(userid);
                item_detail.Name = userdetail.FirstName + " " + userdetail.LastName;
                item_detail.Email = userdetail.EmailAddress;
                var review_existing = db.StockItemReviewTables.Where(u => u.ReviewBy_UserID == userid && u.StockItemID == itemid).FirstOrDefault();
                if (review_existing != null)
                {
                    item_detail.Rating = Convert.ToString(review_existing.Rating);
                    item_detail.ReviewDetails = review_existing.ReviewDetails;
                }
                else
                {
                    item_detail.Rating = "0";
                    item_detail.ReviewDetails = string.Empty;
                }
            }

            // Getting Item Details
            var item = db.StockItemTables.Find(itemid);
            var visiblestatus = db.VisibleStatusTables.Find(item.VisibleStatusID).VisibleStatus;
            var createdby = db.UserTables.Find(item.CreatedBy_UserID).UserName;
            var replace = item.ItemPhotoPath.Split('/');
            string x_large_photopath = string.Empty;
            for (int i = 0; i < replace.Count(); i++)
            {
                if (replace[i].Contains(".jpg"))
                {
                    x_large_photopath = x_large_photopath + "x_" + replace[i];
                }
                else
                {
                    x_large_photopath = x_large_photopath + replace[i] + "/";
                }
            }

            item_detail.Item = new ItemMV()
            {
                StockItemID = item.StockItemID,
                StockItemCategory = item.StockItemCategoryTable.StockItemCategory,
                ItemPhotoPath = x_large_photopath,
                StockItemTitle = item.StockItemTitle,
                ItemSize = item.ItemSize,
                UnitPrice = item.UnitPrice,
                RegisterDate = item.RegisterDate,
                VisibleStatus = visiblestatus,
                CreatedBy = createdby,
                OrderType = item.OrderTypeTable.OrderType,

            };

            var reviews = db.StockItemReviewTables.Where(i => i.StockItemID == itemid).ToList();
            int total_reviews = 0;
            int total_rating = 0;
            for (int i = 0; i < reviews.Count(); i++)
            {

                total_reviews = total_reviews + 1;
                total_rating = total_rating + reviews[i].Rating;

                var review_user = db.UserTables.Find(reviews[i].ReviewBy_UserID).UserName;
                var userdetail = db.UserTables.Find(reviews[i].ReviewBy_UserID).UserDetailTable;
                var user_photo_path = userdetail != null ? userdetail.PhotoPath : "~/Content/ProfilePhoto/user_default.png";
                var review_days = (DateTime.Now - reviews[i].ReviewDateTime).TotalDays;
                item_detail.Reviews.Add(new ItemReviewMV()
                {
                    Review_Days = (int)review_days,
                    Rating = reviews[i].Rating,
                    ReviewBy_User = review_user,
                    UserPhotoPath = user_photo_path,
                    ReviewDetails = reviews[i].ReviewDetails
                });
            }
            int total_reviews_score = total_reviews * 5;
            int item_rating = total_reviews_score > 0 ? (total_rating / total_reviews_score) * 5 : 0;
            item_detail.Item.Rating = item_rating;

            // getting ingredients 
            foreach (var ingredient in db.StockItemIngredientTables.Where(i => i.StockItemID == itemid).ToList())
            {
                var ingredient_createdby = db.UserTables.Find(ingredient.CreatedBy_UserID).UserName;
                item_detail.Ingredients.Add(
                    new StockItemIngredientMV()
                    {
                        StockItem = item.StockItemTitle,
                        StockItemIngredientID = ingredient.StockItemIngredientID,
                        StockItemIngredientTitle = ingredient.StockItemIngredientTitle,
                        StockItemIngredientPhotoPath = ingredient.StockItemIngredientPhotoPath,
                        StockItemID = ingredient.StockItemID,
                        CreatedBy = ingredient_createdby
                    });
            }

            // getting related items
            foreach (var related_item in db.StockItemTables.Where(c => c.StockItemCategoryID == item.StockItemCategoryID).ToList())
            {
                var related_visiblestatus = db.VisibleStatusTables.Find(related_item.VisibleStatusID).VisibleStatus;
                var related_createdby = db.UserTables.Find(related_item.CreatedBy_UserID).UserName;
                item_detail.Related_Items.Add(new ItemMV()
                {
                    StockItemID = related_item.StockItemID,
                    StockItemCategory = related_item.StockItemCategoryTable.StockItemCategory,
                    ItemPhotoPath = related_item.ItemPhotoPath,
                    StockItemTitle = related_item.StockItemTitle,
                    ItemSize = related_item.ItemSize,
                    UnitPrice = related_item.UnitPrice,
                    RegisterDate = related_item.RegisterDate,
                    VisibleStatus = related_visiblestatus,
                    CreatedBy = related_createdby,
                    OrderType = related_item.OrderTypeTable.OrderType,

                });
            }

            return View(item_detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDetail(ItemDetailMV itemDetailMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                return RedirectToAction("Index", "Home");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            var review_existing = db.StockItemReviewTables.Where(u => u.ReviewBy_UserID == userid && u.StockItemID == itemDetailMV.StockItemID).FirstOrDefault();
            if (review_existing != null)
            {
                review_existing.ReviewDateTime = DateTime.Now;
                review_existing.Rating = Convert.ToInt32(itemDetailMV.Rating);
                review_existing.ReviewDetails = itemDetailMV.ReviewDetails;
                db.Entry(review_existing).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                var itemreview = new StockItemReviewTable();
                itemreview.StockItemID = itemDetailMV.StockItemID;
                itemreview.ReviewBy_UserID = userid;
                itemreview.ReviewDateTime = DateTime.Now;
                itemreview.Rating = Convert.ToInt32(itemDetailMV.Rating);
                itemreview.ReviewDetails = itemDetailMV.ReviewDetails;
                db.StockItemReviewTables.Add(itemreview);
                db.SaveChanges();
            }
            return RedirectToAction("ProductDetail", new { itemid = itemDetailMV.StockItemID });
        }




    }

}


