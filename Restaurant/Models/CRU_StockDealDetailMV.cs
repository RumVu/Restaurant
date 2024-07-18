using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class CRU_StockDealDetailMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public CRU_StockDealDetailMV() { }
        public CRU_StockDealDetailMV(int stockdealid)
        {
            GetDealItems(stockdealid);
            StockDealID = stockdealid;
        }
        public CRU_StockDealDetailMV(int stockdealid, int stockdealdetailid)
        {
            GetDealItems(stockdealid);
            StockDealID = stockdealid;
            StockDealDetailID = stockdealdetailid;

            var edit = db.StockDealDetailTables.Find(stockdealdetailid);
            if (edit != null)
            {
                StockDealDetailID = edit.StockDealDetailID;
                StockDealID = edit.StockDealID;
                StockItemID = edit.StockItemID;
                Discount = edit.Discount;
                Quantity = edit.Quantity;
                VisibleStatusID = edit.VisibleStatusID;
            }
            else
            {
                StockDealDetailID = stockdealdetailid;
                StockDealID = stockdealid;
                StockItemID = 0;
                Discount = 0;
                Quantity = 0;
                VisibleStatusID = 0;
            }
        }
        public int StockDealDetailID { get; set; }
        public int StockDealID { get; set; }
        public int StockItemID { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public int VisibleStatusID { get; set; }
        public List<StockDealDetailMV> DealItems { get; set; }

        public void GetDealItems(int? dealid)
        {
            DealItems = new List<StockDealDetailMV>();
            foreach (var item in db.StockDealDetailTables.Where(d => d.StockDealID == dealid).ToList())
            {
                var visible = db.VisibleStatusTables.Find(item.VisibleStatusID).VisibleStatus;
                var stockitem = item.StockItemTable;
                DealItems.Add(new StockDealDetailMV()
                {
                    StockDealDetailID = item.StockDealDetailID,
                    StockDealID = item.StockDealID,
                    StockItemID = item.StockItemID,
                    Discount = item.Discount,
                    Quantity = item.Quantity,
                    VisibleStatus = visible,
                    ItemPhotoPath = stockitem.ItemPhotoPath,
                    StockItemTitle = stockitem.StockItemTitle,
                    ItemSize = stockitem.ItemSize,
                    UnitPrice = stockitem.UnitPrice,
                    OrderType = stockitem.OrderTypeTable.OrderType
                });
            }
        }
    }
}