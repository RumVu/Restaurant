using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Reg_UserMV
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Required*")]
        public int UserTypeID { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Match!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Select Gender")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public System.DateTime RegisterationDate { get; set; }
        public int UserStatusID { get; set; }
        public Nullable<System.DateTime> UserStatusChangeDate { get; set; }
    }
}