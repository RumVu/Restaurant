using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class UserTypeMV
    {
        [Display(Name = "#Unique No")]
        public int UserTypeID { get; set; }
        [Display(Name = "User Type")]
        [Required(ErrorMessage = "Required*")]
        public string UserType { get; set; }
    }
}