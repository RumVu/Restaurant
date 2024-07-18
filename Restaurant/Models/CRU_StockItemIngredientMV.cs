using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dblayer;

namespace Restaurant.Models
{
    public class CRU_StockItemIngredientMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public CRU_StockItemIngredientMV() { }
        public CRU_StockItemIngredientMV(int? id)
        {
            StockItemID = id != null ? (int)id : 0;
            GetIngredients();
        }
        public int StockItemIngredientID { get; set; }
        public int StockItemID { get; set; }
        public string StockItemIngredientPhotoPath { get; set; }
        public string StockItemIngredientTitle { get; set; }

        [NotMapped]
        [Display(Name = "Ingredient Photo")]
        public HttpPostedFileBase PhotoPath { get; set; }
        public virtual List<StockItemIngredientMV> Lists { get; set; }
        private void GetIngredients()
        {
            Lists = new List<StockItemIngredientMV>();
            var ingredients = db.StockItemIngredientTables.Where(i => i.StockItemID == StockItemID).ToList();
            foreach (var ingredient in ingredients)
            {
                var itemname = ingredient.StockItemTable.StockItemTitle;
                var createdby = db.UserTables.Find(ingredient.CreatedBy_UserID).UserName;
                Lists.Add(new StockItemIngredientMV()
                {
                    StockItemIngredientID = ingredient.StockItemIngredientID,
                    StockItemID = ingredient.StockItemID,
                    StockItem = itemname,
                    StockItemIngredientPhotoPath = ingredient.StockItemIngredientPhotoPath,
                    StockItemIngredientTitle = ingredient.StockItemIngredientTitle,
                    CreatedBy = createdby
                });
            }
        }
    }
}