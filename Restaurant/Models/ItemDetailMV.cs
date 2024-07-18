using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class ItemDetailMV
    {
        public ItemDetailMV()
        {
            Ingredients = new List<StockItemIngredientMV>();
            Reviews = new List<ItemReviewMV>();
            Related_Items = new List<ItemMV>();
            RatingList = new List<Rating>
            {
                new Rating{ID="1" , Type = "Worst"},
                new Rating{ID="2" , Type = "Bad"},
                new Rating{ID="3" , Type = "Neutral"},
                new Rating{ID="4" , Type = "Good"},
                new Rating{ID="5" , Type = "Excellent"}
            };
        }

        public ItemMV Item { get; set; }
        public List<StockItemIngredientMV> Ingredients { get; set; }
        public List<ItemReviewMV> Reviews { get; set; }
        public List<ItemMV> Related_Items { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int StockItemID { get; set; }
        [Required(ErrorMessage = "Rating Required")]
        [Display(Name = "Rating :")]
        public string Rating { get; set; }
        public List<Rating> RatingList { get; set; }
        public string ReviewDetails { get; set; }
    }
    public class Rating
    {
        public string ID { get; set; }
        public string Type { get; set; }
    }
}