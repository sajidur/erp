using System;

namespace RexERP_MVC.ViewModel
{
    public class TempSalesDetailsResponse
    {
        public int Id { get; set; }
        public int SalesMasterId { get; set; }
        public string SalesInvoice { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> APIId { get; set; }
        public int Qty { get; set; }
        public int WarehouseId { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual APIResponse API { get; set; }
        public virtual BrandResponse Brand { get; set; }
        public virtual ProductResponse Product { get; set; }
        public virtual SizeResponse Size { get; set; }
    }
}