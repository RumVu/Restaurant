using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class UserAddressMV
    {
        public int UserAddressID { get; set; }
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
        public string VisibleStatus { get; set; }
        public string UserName { get; set; }
    }
}