using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dblayer;
namespace Restaurant.Models
{
    public class CRU_VisibleStatusMV
    {
        RemyDbEntities db = new RemyDbEntities();

        public CRU_VisibleStatusMV()
        {
            GetVisbleStatus();
        }

        public CRU_VisibleStatusMV(int? id)
        {
            GetVisbleStatus();
            var editrecord = db.VisibleStatusTables.Find(id);
            if (editrecord != null)
            {
                VisibleStatusID = editrecord.VisibleStatusID;
                VisibleStatus = editrecord.VisibleStatus;
            }
            else
            {
                VisibleStatusID = 0;
                VisibleStatus = string.Empty;
            }
        }


        [Display(Name = "#Unique No")]
        public int VisibleStatusID { get; set; }

        [Display(Name = "Visible Status")]
        [Required(ErrorMessage = "Field Required*")]
        public string VisibleStatus { get; set; }
        public virtual List<VisibleStatusMV> List_VisibleStatus { get; set; }

        private void GetVisbleStatus()
        {
            List_VisibleStatus = new List<VisibleStatusMV>();
            foreach (var status in db.VisibleStatusTables.ToList())
            {
                List_VisibleStatus.Add(new VisibleStatusMV()
                {
                    VisibleStatusID = status.VisibleStatusID,
                    VisibleStatus = status.VisibleStatus
                });
            }
        }
    }
}