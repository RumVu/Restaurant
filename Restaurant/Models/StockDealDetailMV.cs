using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class StockDealDetailMV
    {
        public int StockDealDetailID { get; set; }
        public int StockDealID { get; set; }
        public int StockItemID { get; set; }
        public string ItemPhotoPath { get; set; }
        public string StockItemTitle { get; set; }
        public int Quantity { get; set; }
        public string ItemSize { get; set; }
        public double UnitPrice { get; set; }
        public string OrderType { get; set; }
        public double Discount { get; set; }
        public string VisibleStatus { get; set; }
    }
}