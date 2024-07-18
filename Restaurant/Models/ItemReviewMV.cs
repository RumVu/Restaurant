using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class ItemReviewMV
    {
        public int Review_Days { get; set; }
        public string ReviewBy_User { get; set; }
        public string UserPhotoPath { get; set; }
        public int Rating { get; set; }
        public string ReviewDetails { get; set; }
    }

}