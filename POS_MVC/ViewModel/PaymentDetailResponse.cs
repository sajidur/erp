using System;

namespace RexERP_MVC.ViewModel
{
    public class PaymentDetailResponse
    {
        public int Id { get; set; }
        public Nullable<int> PaymentMasterId { get; set; }
        public Nullable<int> LedgerId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public string ChequeDateString
        {
            get
            {
                try
                {
                    return this.ChequeDate.Value.ToString("dd-MMM-yyyy");
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
                this.ChequeDate.Value.ToString("dd-MMM-yyyy");
            }
        }
        public Nullable<System.DateTime> ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ApprovedNotes { get; set; }
        public Nullable<System.DateTime> ApprovedBy { get; set; }
        public virtual AccountLedgerResponse AccountLedger { get; set; }
    }
}