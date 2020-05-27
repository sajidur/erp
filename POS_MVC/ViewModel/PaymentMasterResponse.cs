using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class PaymentMasterResponse
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<decimal> SuffixPrefixId { get; set; }
        public Nullable<System.DateTime> LedgerDate { get; set; }
        public string PostDate
        {
            get
            {
                return this.LedgerDate.Value.ToString("dd-MMM-yyyy");
            }
            set
            {
                this.LedgerDate.Value.ToString("dd-MMM-yyyy");
            }
        }
        public Nullable<int> LedgerId { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Narration { get; set; }
        public Nullable<int> VoucherTypeId { get; set; }
        public Nullable<int> FinancialYearId { get; set; }
        public Nullable<System.DateTime> ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ApprovedNotes { get; set; }
        public Nullable<System.DateTime> ApprovedBy { get; set; }

        public virtual AccountLedgerResponse AccountLedger { get; set; }
        public virtual ICollection<PaymentDetailResponse> PaymentDetails { get; set; }
    }
}