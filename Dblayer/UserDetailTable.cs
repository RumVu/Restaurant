//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dblayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetailTable
    {
        public int UserDetailID { get; set; }
        public int UserID { get; set; }
        public System.DateTime UserDetailProviderDate { get; set; }
        public string PhotoPath { get; set; }
        public string ExperenceLevel { get; set; }
        public string CNIC { get; set; }
        public string EducationLevel { get; set; }
        public string EducationLastDegreeScanPhoto { get; set; }
        public string LastExperenceScanPhotoPath { get; set; }
        public int CreatedBy_UserID { get; set; }
    
        public virtual UserTable UserTable { get; set; }
    }
}