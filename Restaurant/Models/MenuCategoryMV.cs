using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class MenuCategoryMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public MenuCategoryMV(int? categoryid)
        {
            GetItems(categoryid);
        }
        public string MenuCategory { get; set; }
        public List<StockMenuItemMV> Lists { get; set; }

        public void GetItems(int? categoryid)
        {
            Lists = new List<StockMenuItemMV>();
            foreach (var item in db.StockMenuItemTables.Where(c => c.StockMenuCategoryID == categoryid).ToList())
            {
                var visiblestatus = db.VisibleStatusTables.Find(item.VisibleStatusID).VisibleStatus;
                var createdby = db.UserTables.Find(item.CreatedBy_UserID).UserName;
                var getitem = db.StockItemTables.Find(item.StockItemID);
                Lists.Add(new StockMenuItemMV()
                {
                    StockMenuItemID = item.StockMenuItemID,
                    StockMenuCategoryID = item.StockMenuCategoryID,
                    StockItemID = item.StockItemID,
                    StockItemTitle = item.StockItemTable.StockItemTitle,
                    VisibleStatus = visiblestatus,
                    CreateBy = createdby,
                    ItemPhotoPath = item.StockItemTable.ItemPhotoPath,
                    ItemSize = item.StockItemTable.ItemSize,
                    UnitPrice = item.StockItemTable.UnitPrice,
                    RegisterDate = item.StockItemTable.RegisterDate,
                    OrderType = getitem.OrderTypeTable.OrderType
                });
            }
        }
    }
}