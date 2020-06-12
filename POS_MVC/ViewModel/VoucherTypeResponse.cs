using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class VoucherTypeResponse
    {
        public int Id { get; set; }
        public string VoucherTypeName { get; set; }
        public string TypeOfVoucher { get; set; }
        public string MethodOfVoucherNumbering { get; set; }
        public Nullable<bool> IsTaxApplicable { get; set; }
        public string Narration { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<int> MasterId { get; set; }
        public string Declaration { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public string Heading3 { get; set; }
        public string Heading4 { get; set; }
    }
}