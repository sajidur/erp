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
    
    public partial class StockOut
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> BaleWeight { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<decimal> BaleQty { get; set; }
        public Nullable<decimal> WeightInMon { get; set; }
        public Nullable<int> APIId { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> AlreadyProcessed { get; set; }
        public Nullable<int> InventoryId { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string SizeName { get; set; }
        public string BrandName { get; set; }
    
        public virtual API API { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
