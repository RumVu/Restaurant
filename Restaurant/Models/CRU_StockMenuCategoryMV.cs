using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class CRU_StockMenuCategoryMV
    {

        RemyDbEntities db = new RemyDbEntities();
        public CRU_StockMenuCategoryMV()
        {
            GetData();
        }
        public CRU_StockMenuCategoryMV(int? id)
        {
            GetData();
            var edit = db.StockMenuCategoryTables.Find(id);
            if (edit != null)
            {
                StockMenuCategoryID = edit.StockMenuCategoryID;
                StockMenuCategory = edit.StockMenuCategory;
                CreatedBy_UserID = edit.CreatedBy_UserID;
            }
            else
            {
                StockMenuCategoryID = 0;
                StockMenuCategory= string.Empty;
                CreatedBy_UserID= 0;
            }
        }
        public int StockMenuCategoryID { get; set; }
        public string StockMenuCategory { get; set; }
        public int CreatedBy_UserID { get; set; }
        public virtual List<StockMenuCategoryMV> List { get; set; }

        private void GetData()
        {
            List = new List<StockMenuCategoryMV>();
            foreach (var mcategory in db.StockMenuCategoryTables.ToList())
            {
                var username = db.UserTables.Find(mcategory.CreatedBy_UserID).UserName;
                List.Add(new StockMenuCategoryMV()
                {
                    StockMenuCategoryID = mcategory.StockMenuCategoryID,
                    StockMenuCategory = mcategory.StockMenuCategory,
                    CreatedBy = username,

                });
            }
        }
    } 
}