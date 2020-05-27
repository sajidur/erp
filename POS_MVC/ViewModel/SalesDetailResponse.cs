using System;

namespace RexERP_MVC.ViewModel
{
    public class SalesDetailResponse
    {
        public decimal Amount
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public bool? IsActive
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public virtual ProductResponse Product
        {
            get;
            set;
        }

        public int ProductId
        {
            get;
            set;
        }

        public string SalesInvoice
        {
            get;
            set;
        }

        public int SalesMasterId
        {
            get;
            set;
        }

        public decimal TotalQtyInKG
        {
            get;
            set;
        }

        public string UpdatedBy
        {
            get;
            set;
        }

        public string UpdatedDate
        {
            get;
            set;
        }

        public int WarehouseId
        {
            get;
            set;
        }
        public Nullable<int> APIId { get; set; }
        public string APIName { get; set; }
        public virtual APIResponse API { get; set; }

        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public Nullable<int> SizeId { get; set; }
        public string SizeName { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
    }
}