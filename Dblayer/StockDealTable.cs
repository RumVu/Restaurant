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
    
    public partial class StockDealTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockDealTable()
        {
            this.OrderDealDetailTables = new HashSet<OrderDealDetailTable>();
            this.StockDealDetailTables = new HashSet<StockDealDetailTable>();
        }
    
        public int StockDealID { get; set; }
        public string StockDealTitle { get; set; }
        public double DealPrice { get; set; }
        public int VisibleStatusID { get; set; }
        public Nullable<System.DateTime> StockDealStartDate { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<System.DateTime> StockDealEndDate { get; set; }
        public System.DateTime StockDealRegisterDate { get; set; }
        public string DealPhoto { get; set; }
    
        public virtual CartDealTable CartDealTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDealDetailTable> OrderDealDetailTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockDealDetailTable> StockDealDetailTables { get; set; }
        public virtual VisibleStatusTable VisibleStatusTable { get; set; }
    }
}
