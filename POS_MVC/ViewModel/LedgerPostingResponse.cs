﻿using System;

namespace RexERP_MVC.ViewModel
{
    public class LedgerPostingResponse
    {
        public int Id { get; set; }
        public DateTime PostingDate { get; set; }
        public int VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public int LedgerId { get; set; }
        public decimal Opening { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public int YearId { get; set; }
        public string InvoiceNo { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string PostDate { get { return PostingDate.ToString("dd-MM-yyyy"); } set { PostingDate.ToString("dd-MM-yyyy"); } }
        public virtual AccountLedgerResponse AccountLedger { get; set; }
        public virtual VoucherTypeResponse VoucherType { get; set; }

    }
}