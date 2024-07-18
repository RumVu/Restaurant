using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class FilterCategoryMV
    {
        public int StockMenuCategoryID { get; set; }
        public string StockMenuCategory { get; set; }
        public bool CategoryStatus { get; set; }
    }
}