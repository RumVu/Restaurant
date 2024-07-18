using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class StockItemIngredientMV
    {
        public int StockItemIngredientID { get; set; }
        public int StockItemID { get; set; }
        public string StockItem { get; set; }
        public string StockItemIngredientPhotoPath { get; set; }
        public string StockItemIngredientTitle { get; set; }
        public string CreatedBy { get; set; }
    }
}