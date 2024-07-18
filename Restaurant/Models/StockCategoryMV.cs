using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{

    public class StockCategoryMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public StockCategoryMV(int? categoryid)
        {
            GetItems(categoryid);
        }
        public string StockCategory { get; set; }
        public List<StockItemMV> Lists { get; set; }

        public void GetItems(int? categoryid)
        {
            Lists = new List<StockItemMV>();
            foreach (var item in db.StockItemTables.Where(c => c.StockItemCategoryID == categoryid).ToList())
            {
                var visiblestatus = db.VisibleStatusTables.Find(item.VisibleStatusID).VisibleStatus;
                var createdby = db.UserTables.Find(item.CreatedBy_UserID).UserName;
                Lists.Add(new StockItemMV()
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