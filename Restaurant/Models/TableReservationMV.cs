using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class TableReservationMV
    {
        public int BookingTableID { get; set; }
        public string BookingUserName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.DateTime ReservationDateTime { get; set; }
        public int NoOfPersons { get; set; }
        public string ProcessBy_User { get; set; }
        public string BookingStatus { get; set; }
        public string Description { get; set; }
    }
}