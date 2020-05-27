using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.RequestModel
{
    public class PaymentAuthorizationRequest
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

    }
}