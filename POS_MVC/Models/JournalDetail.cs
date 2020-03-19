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
    
    public partial class JournalDetail
    {
        public int Id { get; set; }
        public Nullable<int> JournalMasterId { get; set; }
        public Nullable<int> LedgerId { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public Nullable<System.DateTime> ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    
        public virtual AccountLedger AccountLedger { get; set; }
        public virtual JournalDetail JournalDetails1 { get; set; }
        public virtual JournalDetail JournalDetail1 { get; set; }
    }
}
