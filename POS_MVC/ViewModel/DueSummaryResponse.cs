﻿using System;

namespace RexERP_MVC.ViewModel
{
    public class DueSummaryResponse
    {
        public int LedgerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ContactPersonPhone { get; set; }
        public Nullable<int> TotalInvoice { get; set; }
        public string reportType { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}