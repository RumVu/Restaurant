using Dblayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Restaurant.Models
{
    public class CRU_TableReservationMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public CRU_TableReservationMV() { }
        public CRU_TableReservationMV(int usertypeid, int userid, int id = 0)
        {
            GetReservationList(usertypeid, userid);
            if (userid > 0)
            {
                var user = db.UserTables.Find(userid);
                FullName = user.FirstName + " " + user.LastName;
                EmailAddress = user.EmailAddress;
                MobileNo = user.ContactNo;
            }
            ReservationDate = null;
            ReservationTime = null;
            var edit = db.BookingTblTables.Find(id);
            if (edit != null)
            {
                BookingTableID = edit.BookingTableID;
                FullName = edit.FullName;
                EmailAddress = edit.EmailAddress;
                MobileNo = edit.MobileNo;
                ReservationDate = edit.ReservationDateTime.Date;
                ReservationTime = edit.ReservationDateTime.ToString("hh:mm:ss tt");
                NoOfPersons = edit.NoOfPersons;
                BookingStatusID = edit.BookingStatusID;
                Description = edit.Description;
            }
            else
            {
                BookingTableID = 0;
                FullName = string.Empty;
                EmailAddress = string.Empty;
                MobileNo = string.Empty;
                ReservationDate = null;
                ReservationTime = string.Empty;
                NoOfPersons = null;
                BookingStatusID = 0;
                Description = string.Empty;
            }
        }
        public int BookingTableID { get; set; }
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime BookingDate { get; set; }
        public System.DateTime? ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int? NoOfPersons { get; set; }
        public int BookingStatusID { get; set; }
        public string Description { get; set; }

        public List<TableReservationMV> ReservationList { get; set; }
        public void GetReservationList(int usertypeid, int userid)
        {
            ReservationList = new List<TableReservationMV>();
            if (usertypeid == 4) // Customer
            {
                var list = db.BookingTblTables.Where(u => u.BookingUserID == userid).ToList();
                if (list.Count > 0)
                {
                    list.OrderByDescending(o => o.BookingTableID).ToList();
                }
                foreach (var item in list)
                {
                    var bookingusername = item.UserTable.UserName;

                    var processbyuser = item.ProcessBy_UserID > 0 ?
                        db.UserTables.Find(item.ProcessBy_UserID).UserName :
                        string.Empty;

                    var bookingstatus = item.BookingStatusTable.BookingStatus;
                    ReservationList.Add(new TableReservationMV
                    {
                        BookingTableID = item.BookingTableID,
                        BookingUserName = bookingusername,
                        FullName = item.FullName,
                        EmailAddress = item.EmailAddress,
                        MobileNo = item.MobileNo,
                        BookingDate = item.BookingDate,
                        ReservationDateTime = item.ReservationDateTime,
                        NoOfPersons = item.NoOfPersons,
                        ProcessBy_User = processbyuser,
                        BookingStatus = bookingstatus,
                        Description = item.Description
                    });
                }
            }
            else if (usertypeid == 1 || usertypeid == 2 || usertypeid == 3)
            {
                var list = db.BookingTblTables.ToList();
                if (list.Count > 0)
                {
                    list.OrderByDescending(o => o.BookingTableID).ToList();
                }
                foreach (var item in list)
                {
                    var bookingusername = item.UserTable.UserName;

                    var processbyuser = item.ProcessBy_UserID > 0 ?
                        db.UserTables.Find(item.ProcessBy_UserID).UserName :
                        string.Empty;

                    var bookingstatus = item.BookingStatusTable.BookingStatus;
                    ReservationList.Add(new TableReservationMV
                    {
                        BookingTableID = item.BookingTableID,
                        BookingUserName = bookingusername,
                        FullName = item.FullName,
                        EmailAddress = item.EmailAddress,
                        MobileNo = item.MobileNo,
                        BookingDate = item.BookingDate,
                        ReservationDateTime = item.ReservationDateTime,
                        NoOfPersons = item.NoOfPersons,
                        ProcessBy_User = processbyuser,
                        BookingStatus = bookingstatus,
                        Description = item.Description
                    });
                }
            }
        }
    }
}
