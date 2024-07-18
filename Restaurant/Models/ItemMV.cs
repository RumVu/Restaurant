using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class ItemMV
    {
        public int StockItemID { get; set; }
        public string StockItemCategory { get; set; }
        public string ItemPhotoPath { get; set; }
        public string StockItemTitle { get; set; }
        public string ItemSize { get; set; }
        public double UnitPrice { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string VisibleStatus { get; set; }
        public string CreatedBy { get; set; }
        public string OrderType { get; set; }
        public int Rating { get; set; }
    }
}