using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class User_ProfileMV
    {
        public int UserID { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ContactNo { get; set; }
        public string GenderTitle { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime RegisterationDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string FullAddress { get; set; }
        public string UserStatus { get; set; }
        public int UserStatusID { get; set; }
        public Nullable<System.DateTime> UserStatusChangeDate { get; set; }
        public System.DateTime UserDetailProviderDate { get; set; }
        public string PhotoPath { get; set; }
        public string CNIC { get; set; }
        public string EducationLevel { get; set; }
        public string ExperenceLevel { get; set; }
        public string EducationLastDegreeScanPhoto { get; set; }
        public string LastExperenceScanPhotoPath { get; set; }

        [NotMapped]
        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase UserPhoto { get; set; }
        [NotMapped]
        [Display(Name = "Education Last Degree Scan Photo")]
        public HttpPostedFileBase EducationLastDegreePhoto { get; set; }
        [NotMapped]
        [Display(Name = "Last Experience Scan Photo")]
        public HttpPostedFileBase ExperenceLastPhoto { get; set; }

    }
}