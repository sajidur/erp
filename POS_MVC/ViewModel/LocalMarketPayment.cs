﻿namespace RexERP_MVC.ViewModel
{
    public class LocalMarketPayment
    {
        public int LedgerId { get; set; }
        public string PostingDate { get; set; }
        public string Party { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RestAmount { get; set; }
    }
}