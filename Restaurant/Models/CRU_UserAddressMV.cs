using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class CRU_UserAddressMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public CRU_UserAddressMV()
        {
            GetUserAddress();
        }
        public CRU_UserAddressMV(int? id)
        {
            GetUserAddress();

            var editaddress = db.UserAddressTables.Find(id);
            if (editaddress != null)
            {
                UserAddressID = editaddress.UserAddressID;
                AddressTypeID = editaddress.AddressTypeID;
                FullAddress = editaddress.FullAddress;
                VisibleStatusID = editaddress.VisibleStatusID;
            }
            else
            {
                UserAddressID = 0;
                AddressTypeID = 0;
                FullAddress = string.Empty;
                VisibleStatusID = 0;
            }
        }

        public int UserAddressID { get; set; }
        public int AddressTypeID { get; set; }
        public string FullAddress { get; set; }
        public int VisibleStatusID { get; set; }

        public virtual List<UserAddressMV> List { get; set; }
        private void GetUserAddress()
        {
            List = new List<UserAddressMV>();
            foreach (var address in db.UserAddressTables.ToList())
            {
                List.Add(new UserAddressMV()
                {
                    UserAddressID = address.UserAddressID,
                    AddressType = address.AddressTypeTable.AddressType,
                    FullAddress = address.FullAddress,
                    VisibleStatus = address.VisibleStatusTable.VisibleStatus,
                    UserName = address.UserTable.UserName
                });
            }
        }
    }
}