//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RexERP_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesDetail()
        {
            this.SalesReturns = new HashSet<SalesReturn>();
        }
    
        public int Id { get; set; }
        public int SalesMasterId { get; set; }
        public string SalesInvoice { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> APIId { get; set; }
        public string APIName { get; set; }
        public string SizeName { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int WarehouseId { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DeliveryStatus { get; set; }
    
        public virtual API API { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Product Product { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
        public virtual Size Size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturn> SalesReturns { get; set; }
    }
}
