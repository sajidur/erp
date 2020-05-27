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
    
    public partial class AdvancePayment
    {
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> LedgerId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> SalaryMonth { get; set; }
        public string ChequeNumber { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public string Narration { get; set; }
        public Nullable<System.DateTime> ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public Nullable<decimal> SuffixPrefixId { get; set; }
        public Nullable<int> VoucherTypeId { get; set; }
        public Nullable<int> FinancialYearId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    
        public virtual AccountLedger AccountLedger { get; set; }
        public virtual VoucherType VoucherType { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
