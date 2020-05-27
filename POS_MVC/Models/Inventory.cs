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
    
    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            this.SalesOrders = new HashSet<SalesOrder>();
            this.StockOuts = new HashSet<StockOut>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string InventoryGuid { get; set; }
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> APIId { get; set; }
        public Nullable<decimal> OpeningQty { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> ProductionIn { get; set; }
        public Nullable<decimal> ProductionOut { get; set; }
        public Nullable<decimal> ReturnQty { get; set; }
        public Nullable<decimal> Faulty { get; set; }
        public Nullable<decimal> SalesQty { get; set; }
        public decimal BalanceQty { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalesPrice { get; set; }
        public Nullable<decimal> Costprice { get; set; }
        public Nullable<decimal> ProductionPrice { get; set; }
        public string Notes { get; set; }
        public string GoodsType { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual API API { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual WareHouse WareHouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockOut> StockOuts { get; set; }
    }
}
