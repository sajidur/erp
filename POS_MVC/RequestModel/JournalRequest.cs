using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.RequestModel
{
    public class JournalRequest
    {
        public int LedgerId { get; set; }
        public string LedgerName { get; set; }
        public string DrOrCr { get; set; }
        public int Amount { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }

    }
}