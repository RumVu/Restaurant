using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class FilterOrderTypeMV
    {
        public int OrderTypeID { get; set; }
        public string OrderType { get; set; }
        public bool OrderTypeStatus { get; set; }
    }
}