using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dblayer;
namespace Restaurant.Models
{
    public class CRU_UserTypeMV
    {
        public CRU_UserTypeMV()
        {
            List_UserTypes = new List<UserTypeMV>();
            foreach (var usertype in new RemyDbEntities().UserTypeTables.ToList())
            {
                List_UserTypes.Add(new UserTypeMV()
                {
                    UserTypeID = usertype.UserTypeID,
                    UserType = usertype.UserType
                });
            }
        }

        public CRU_UserTypeMV(int? id)
        {
            List_UserTypes = new List<UserTypeMV>();
            foreach (var usertype in new RemyDbEntities().UserTypeTables.ToList())
            {
                List_UserTypes.Add(new UserTypeMV()
                {
                    UserTypeID = usertype.UserTypeID,
                    UserType = usertype.UserType
                });
            }

            var editusertype = new RemyDbEntities().UserTypeTables.Where(u => u.UserTypeID == id).FirstOrDefault();
            if (editusertype != null)
            {
                UserTypeID = editusertype.UserTypeID;
                UserType = editusertype.UserType;
            }
            else
            {
                UserTypeID = 0;
                UserType = string.Empty;
            }
        }

        public int UserTypeID { get; set; }
        public string UserType { get; set; }
        public List<UserTypeMV> List_UserTypes { get; set; }
    }
}