using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class SalaryPackageResponse
    {
        public int Id { get; set; }
        public string SalaryPackageName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        public virtual List<SalaryPackageDetailResponse> SalaryPackageDetails { get; set; }
    }
    public class SalaryPackageDetailResponse
    {
        public int Id { get; set; }
        public int SalaryPackageId { get; set; }
        public Nullable<int> PayHeadId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Narration { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public PayHeadViewModel PayHead { get; set; }
    }
}