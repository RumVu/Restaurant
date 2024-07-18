using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class CartMV
    {
        public int CartID { get; set; }
        public int CartItemID { get; set; }
        public int StockItemID { get; set; }
        public string StockItemTitle { get; set; }
        public string StockItemCategory { get; set; }
        public string ItemPhotoPath { get; set; }
        public string ItemSize { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; }
        public double ItemCost { get; set; } // = Qty * Unit Price
        public string ItemType { get; set; } // it's deal or item
    }
}