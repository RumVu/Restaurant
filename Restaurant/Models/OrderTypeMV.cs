using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class OrderTypeMV
    {
        public int OrderTypeID { get; set; }
        [Required(ErrorMessage = "Required*")]
        public string OrderType { get; set; }

    }
}