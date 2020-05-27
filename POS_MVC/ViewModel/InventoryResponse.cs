using System;

namespace RexERP_MVC.ViewModel
{
    public class InventoryResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> QtyInBale { get; set; }
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
        public Nullable<int> APIId { get; set; }

        public Nullable<decimal> OpeningQty { get; set; }
        public Nullable<decimal> SalesQty { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> Costprice { get; set; }
        public Nullable<decimal> ProductionPrice { get; set; }

        public Nullable<decimal> ProductionIn { get; set; }
        public Nullable<decimal> ProductionOut { get; set; }
        public Nullable<decimal> ReturnQty { get; set; }
        public Nullable<decimal> Faulty { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal BalanceQtyInKG { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalesPrice { get; set; }
        public string Notes { get; set; }
        public string GoodsType { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public ProductResponse Product { get; set; }
        public SupplierResponse Supplier { get; set; }
        public WareHouseResponse WareHouse { get; set; }
        public virtual BrandResponse Brand { get; set; }
        public virtual SizeResponse Size { get; set; }
        public virtual APIResponse API { get; set; }

    }
}