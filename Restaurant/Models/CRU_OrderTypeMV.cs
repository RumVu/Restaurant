using Dblayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class CRU_OrderTypeMV
    {
        public CRU_OrderTypeMV()
        {
            GetData();
        }
        public CRU_OrderTypeMV(int ? id)
        {
            GetData();
            var edit = db.OrderTypeTables.Find(id);
            if (edit != null)
            {
                OrderTypeID = edit.OrderTypeID;
                OrderType = edit.OrderType;
            }
            else
            {
                OrderTypeID=0;
                OrderType=string.Empty;
            }
        }
        RemyDbEntities db = new RemyDbEntities();
        public int OrderTypeID { get; set; }
        [Required(ErrorMessage = "Required*")]
        public string OrderType { get; set; }

        public virtual List<OrderTypeMV> List { get; set; }

        private void GetData()
        {
            List = new List<OrderTypeMV>();
            foreach (var ordertype in db.OrderTypeTables.ToList()) 
            {
                List.Add(new OrderTypeMV()
                {
                    OrderTypeID = ordertype.OrderTypeID,
                    OrderType = ordertype.OrderType,
                });
            
            }
        }
    }     
}