using Dblayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class CRU_StockDealMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public CRU_StockDealMV()
        {
            GetDeal();
        }
        public CRU_StockDealMV(int? id)
        {
            GetDeal();
            var editdeal = db.StockDealTables.Find(id);
            if (editdeal != null)
            {
                StockDealID = editdeal.StockDealID;
                StockDealTitle = editdeal.StockDealTitle;
                DealPrice = editdeal.DealPrice;
                VisibleStatusID = editdeal.VisibleStatusID;
                StockDealStartDate = editdeal.StockDealStartDate;
                Discount = editdeal.Discount;
                StockDealEndDate = editdeal.StockDealEndDate;
                StockDealRegisterDate = editdeal.StockDealRegisterDate;
            }
            else
            {
                StockDealID = 0;
                StockDealTitle = string.Empty;
                DealPrice = 0;
                VisibleStatusID = 0;
                StockDealStartDate = DateTime.Now;
                Discount = 0;
                StockDealEndDate = DateTime.Now.AddMonths(3);
                StockDealRegisterDate = DateTime.Now;
            }
        }
        public int StockDealID { get; set; }
        public string StockDealTitle { get; set; }
        public double DealPrice { get; set; }
        public int VisibleStatusID { get; set; }
        public Nullable<System.DateTime> StockDealStartDate { get; set; } = DateTime.Now;
        public Nullable<double> Discount { get; set; }
        public Nullable<System.DateTime> StockDealEndDate { get; set; } = DateTime.Now.AddMonths(3);
        public System.DateTime StockDealRegisterDate { get; set; } = DateTime.Now;

        [NotMapped]
        [Display(Name = "Deal Photo")]
        public HttpPostedFileBase PhotoPath { get; set; }


        public virtual List<StockDealHeaderMV> Deal { get; set; }

        public void GetDeal()
        {
            Deal = new List<StockDealHeaderMV>();
            foreach (var item in db.StockDealTables.ToList())
            {
                var visible = db.VisibleStatusTables.Find(item.VisibleStatusID).VisibleStatus;
                Deal.Add(new StockDealHeaderMV(item.StockDealID)
                {
                    StockDealID = item.StockDealID,
                    StockDealTitle = item.StockDealTitle,
                    DealPhoto = item.DealPhoto,
                    DealPrice = item.DealPrice,
                    VisibleStatus = visible,
                    StockDealStartDate = Convert.ToDateTime(item.StockDealStartDate),
                    Discount = (double)item.Discount,
                    StockDealEndDate = Convert.ToDateTime(item.StockDealEndDate),
                    StockDealRegisterDate = item.StockDealRegisterDate
                });
            }
        }
    }
}