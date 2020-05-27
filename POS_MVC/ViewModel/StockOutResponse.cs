using System;

namespace RexERP_MVC.ViewModel
{
    public class StockOutResponse
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> BaleWeight { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<decimal> BaleQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
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
        public Nullable<decimal> StockOutPrice { get; set; }

        public virtual APIResponse API { get; set; }
        public virtual BrandResponse Brand { get; set; }
        public virtual ProductResponse Product { get; set; }
        public virtual SizeResponse Size { get; set; }
        public virtual SupplierResponse Supplier { get; set; }
        public virtual WareHouseResponse WareHouse { get; set; }
    }
}