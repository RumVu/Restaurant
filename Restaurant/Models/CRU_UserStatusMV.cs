using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dblayer;
namespace Restaurant.Models
{
    public class CRU_UserStatusMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public CRU_UserStatusMV()
        {
            GetUserStatus();
        }

        public CRU_UserStatusMV(int? id)
        {
            GetUserStatus();
            var editrecord = db.UserStatusTables.Find(id);
            if (editrecord != null)
            {
                UserStatusID = editrecord.UserStatusID;
                UserStatus = editrecord.UserStatus;
            }
            else
            {
                UserStatusID = 0;
                UserStatus = string.Empty;
            }
        }


        [Display(Name = "#Unique No")]
        public int UserStatusID { get; set; }
        [Display(Name = "Account Status")]
        [Required(ErrorMessage = "Field Required*")]
        public string UserStatus { get; set; }
        public virtual List<UserStatusMV> List_UserStatuses { get; set; }


        private void GetUserStatus()
        {
            List_UserStatuses = new List<UserStatusMV>();
            foreach (var userstatus in db.UserStatusTables.ToList())
            {
                List_UserStatuses.Add(new UserStatusMV()
                {
                    UserStatusID = userstatus.UserStatusID,
                    UserStatus = userstatus.UserStatus
                });
            }
        }
    }
}