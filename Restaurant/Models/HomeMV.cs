using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class HomeMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public HomeMV()
        {
            GetMenuCategories();
            GetPopularDishes();
        }
        public virtual List<MenuCategoryMV> Menu { get; set; }
        public void GetMenuCategories()
        {
            Menu = new List<MenuCategoryMV>();
            foreach (var item in db.StockMenuCategoryTables.ToList())
            {
                Menu.Add(new MenuCategoryMV(item.StockMenuCategoryID)
                {
                    MenuCategory = item.StockMenuCategory
                });
            }
        }

        public List<StockItemMV> PopularDishes { get; set; }
        public void GetPopularDishes()
        {
            PopularDishes = new List<StockItemMV>();
            foreach (var item in db.StockItemTables.Where(c => c.StockItemCategoryID == 2 && c.VisibleStatusID == 1).ToList())  // 2 is dishes category id in stockitemcatgorytable
            {
                var visiblestatus = db.VisibleStatusTables.Find(item.VisibleStatusID).VisibleStatus;
                var createdby = db.UserTables.Find(item.CreatedBy_UserID).UserName;
                PopularDishes.Add(new StockItemMV()
                {
                    StockItemID = item.StockItemID,
                    StockItemCategory = item.StockItemCategoryTable.StockItemCategory,
                    ItemPhotoPath = item.ItemPhotoPath,
                    StockItemTitle = item.StockItemTitle,
                    ItemSize = item.ItemSize,
                    UnitPrice = item.UnitPrice,
                    RegisterDate = item.RegisterDate,
                    VisibleStatus = visiblestatus,
                    CreatedBy = createdby,
                    OrderType = item.OrderTypeTable.OrderType,
                });
            }
        }
    }
}